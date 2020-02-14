
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

    }
}
