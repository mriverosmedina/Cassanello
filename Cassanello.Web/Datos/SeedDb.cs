using Cassanello.Web.Datos.Entidades;
using System;
using System.Collections.Generic;
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
            await CheckLaboratorio();
        }

        private async Task CheckLaboratorio()
        {
            if (!_context.Laboratorios.Any())
            {
                _context.Laboratorios.Add(new Laboratorio { CodLaboratorio = 1, NomLaboratorio = "Luis Cassanello" });
                _context.Laboratorios.Add(new Laboratorio { CodLaboratorio = 2, NomLaboratorio = "Faes" });
                _context.Laboratorios.Add(new Laboratorio { CodLaboratorio = 3, NomLaboratorio = "Mentholatum" });
                await _context.SaveChangesAsync();

            }

        }
    }
}
