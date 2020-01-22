using Cassanello.Web.Datos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cassanello.Web.Datos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Visitador> Visitadores { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }       


    }
}
