using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Datos
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1010", "Mario", "Riveros", "tic@cassanello.com.py", "0981728813", "Admin");
            var customer = await CheckUserAsync("1020", "Mario", "Riveros", "customer@cassanello.com.py", "0981728888", "Customer");

            await CheckEpecialidadAsync();
            //await CheckServiceTypesAsync();
            await CheckVisitadorAsync(customer);
            await CheckManagerAsync(manager);
            //await CheckPetsAsync();
            //await CheckAgendasAsync();
        }

        private async Task CheckManagerAsync(Usuario user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Visitadores.Add(new Visitador { Usuario = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckVisitadorAsync(Usuario user)
        {
            if (!_dataContext.Visitadores.Any())
            {
                _dataContext.Visitadores.Add(new Visitador { Usuario = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task<Usuario> CheckUserAsync(string document, string Nombre,
            string Apellido, string email,
            string phone, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new Usuario
                {
                    FirstName = Nombre,
                    LastName = Apellido,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }
            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task CheckEpecialidadAsync()
        {
            if (!_dataContext.Especialidades.Any())
            {

                _dataContext.Especialidades.Add(new Especialidad { Codigo = "CAR", Descripcion = "CARDIOLOGO" });
                _dataContext.Especialidades.Add(new Especialidad { Codigo = "CM", Descripcion = "CLINICA MEDICA" });
                _dataContext.Especialidades.Add(new Especialidad { Codigo = "GIN", Descripcion = "GINECOLOGIA" });
                _dataContext.Especialidades.Add(new Especialidad { Codigo = "OBS", Descripcion = "OBSTETRA" });
                _dataContext.Especialidades.Add(new Especialidad { Codigo = "NUT", Descripcion = "NUTRICIONISTA" });
                _dataContext.Especialidades.Add(new Especialidad { Codigo = "PED", Descripcion = "PEDIATRA" });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
