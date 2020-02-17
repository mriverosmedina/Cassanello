using Cassanello.Web.Datos.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cassanello.Web.Datos
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Visitador> Visitadores { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<Especialidad> Especialidades { get; set; }

        public DbSet<Historico> Historicos { get; set; }

        public DbSet<Laboratorio> Laboratorios { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Manager> Managers { get; set; }

    }
}
