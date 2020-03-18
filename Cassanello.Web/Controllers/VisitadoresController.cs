using Cassanello.Web.Datos;
using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Helpers;
using Cassanello.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VisitadoresController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public VisitadoresController(DataContext context,
            IUserHelper userHelper,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _datacontext = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        // GET: Visitadores
        public IActionResult Index()
        {
            return View(_datacontext.Visitadores
                        .Include(v => v.Usuario)
                        .Include(v => v.Medicos));
        }
        // GET: Visitadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitador = await _datacontext.Visitadores
                                .Include(v => v.Usuario)
                                .Include(v => v.Medicos)
                                .ThenInclude(m => m.Especialidad)
                                .Include(v => v.Medicos)
                                .ThenInclude(m => m.Historicos)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitador == null)
            {
                return NotFound();
            }

            return View(visitador);
        }

        // GET: Visitadores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    Document = model.Document,
                    Email = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Username
                };
                var response = await _userHelper.AddUserAsync(user, model.Password.Trim());
                if (response.Succeeded)
                {
                    var userInDB = await _userHelper.GetUserByEmailAsync(model.Username.Trim());
                    await _userHelper.AddUserToRoleAsync(userInDB, "Customer");

                    var visitador = new Visitador
                    {
                        Agendas = new List<Agenda>(),
                        Medicos = new List<Medico>(),
                        Usuario = userInDB
                    };
                    _datacontext.Visitadores.Add(visitador);
                    try
                    {
                        await _datacontext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.ToString());
                        return View(model);
                    }
                }
                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        // GET: Visitadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitador = await _datacontext.Visitadores
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (visitador == null)
            {
                return NotFound();
            }

            var view = new EditUserViewModel
            {
                Document = visitador.Usuario.Document,
                FirstName = visitador.Usuario.FirstName,
                Id = visitador.Id,
                LastName = visitador.Usuario.LastName,
                PhoneNumber = visitador.Usuario.PhoneNumber
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var visitador = await _datacontext.Visitadores
                    .Include(o => o.Usuario)
                    .FirstOrDefaultAsync(o => o.Id == model.Id);

                visitador.Usuario.Document = model.Document;
                visitador.Usuario.FirstName = model.FirstName;
                visitador.Usuario.LastName = model.LastName;
                visitador.Usuario.PhoneNumber = model.PhoneNumber;

                await _userHelper.UpdateUserAsync(visitador.Usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Visitadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitador = await _datacontext.Visitadores
                .Include(v => v.Medicos)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(v => v.Id == id);
            if (visitador == null)
            {
                return NotFound();
            }

            if (visitador.Medicos.Count > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            await _userHelper.DeleteUserAsync(visitador.Usuario.Email.Trim());
            _datacontext.Visitadores.Remove(visitador);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }      

        private bool VisitadorExists(int id)
        {
            return _datacontext.Visitadores.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddMedico(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var visitador = await _datacontext.Visitadores.FindAsync(id.Value);
            if (visitador == null)
            {
                return NotFound();
            }

            var model = new MedicoViewModel
            {
                Aniversario = DateTime.Today,
                VisitadorId = visitador.Id,
                Especialidades = _combosHelper.GetComboEspecialidades()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedico(MedicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var medico = await _converterHelper.ToMedicoAsync(model, path, true);
                _datacontext.Medicos.Add(medico);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.VisitadorId}");
            }
            model.Especialidades = _combosHelper.GetComboEspecialidades();
            return View(model);
        }

        public async Task<IActionResult> EditMedico(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medico = await _datacontext.Medicos
                         .Include(m => m.Visitador)
                         .Include(m => m.Especialidad)
                         .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToMedicoViewModel(medico));
        }

        [HttpPost]
        public async Task<IActionResult> EditMedico(MedicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = model.ImageUrl;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var medico = await _converterHelper.ToMedicoAsync(model, path, false);
                _datacontext.Medicos.Update(medico);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"Details/{model.VisitadorId}");
            }
            model.Especialidades = _combosHelper.GetComboEspecialidades();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsMedico(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _datacontext.Medicos
                .Include(p => p.Visitador)
                .ThenInclude(o => o.Usuario)
                .Include(p => p.Historicos)
                .FirstOrDefaultAsync(o => o.Id == id.Value);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        public async Task<IActionResult> DeleteHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _datacontext.Historicos
                .Include(h => h.Medico)
                .FirstOrDefaultAsync(h => h.Id == id.Value);
            if (history == null)
            {
                return NotFound();
            }

            _datacontext.Historicos.Remove(history);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsMedico)}/{history.Medico.Id}");
        }





    }
}
