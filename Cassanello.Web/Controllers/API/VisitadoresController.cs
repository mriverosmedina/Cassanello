using Cassanello.Common.Models;
using Cassanello.Web.Datos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VisitadoresController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public VisitadoresController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetVisitadorPorEmail")]
        public async Task<ActionResult> GetVisitador(EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var visitador = await _dataContext.Visitadores
                .Include(v => v.Usuario)
                .Include(v => v.Medicos)
                .ThenInclude(e => e.Especialidad)
                .Include(v => v.Medicos)
                .ThenInclude(v => v.Historicos)
                .FirstOrDefaultAsync(v => v.Usuario.UserName.ToLower() == emailRequest.Correo.ToLower());

            var response = new VisitadorResponse
            {
                Id = visitador.Id,
                FirstName = visitador.Usuario.FirstName,
                LastName = visitador.Usuario.LastName,
                Ducument = visitador.Usuario.Document,
                NroTelefono = visitador.Usuario.PhoneNumber,
                Medicos = visitador.Medicos.Select(m => new MedicoResponse
                {
                    Aniversario = m.Aniversario,
                    Id = m.Id,
                    Nombre = m.Name,
                    Comentario = m.Remarks,
                    Especialidad = m.Especialidad.Descripcion,
                    Historicos = m.Historicos.Select(h => new HistoricoResponse
                    {
                        Fecha = h.Date,
                        Descripcion = h.Description,
                        Id = h.Id,
                        Comentario = h.Remarks
                    }).ToList()
                }).ToList()

            };

            return Ok(visitador);
        }
    }
}