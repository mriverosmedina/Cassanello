using Cassanello.Web.Datos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Datos
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEpecialidadAsync();
            //await CheckServiceTypesAsync();
            //await CheckOwnersAsync();
            //await CheckPetsAsync();
            //await CheckAgendasAsync();
        }

        private async Task CheckEpecialidadAsync()
        {
            if (!_context.Especialidades.Any())
            {

                _context.Especialidades.Add(new Especialidad { Codigo = "CAR", Descripcion = "CARDIOLOGO" });
                _context.Especialidades.Add(new Especialidad { Codigo = "CM", Descripcion = "CLINICA MEDICA" });
                _context.Especialidades.Add(new Especialidad { Codigo = "GIN", Descripcion = "GINECOLOGIA" });
                _context.Especialidades.Add(new Especialidad { Codigo = "OBS", Descripcion = "OBSTETRA" });
                _context.Especialidades.Add(new Especialidad { Codigo = "NUT", Descripcion = "NUTRICIONISTA" });
                _context.Especialidades.Add(new Especialidad { Codigo = "PED", Descripcion = "PEDIATRA" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
