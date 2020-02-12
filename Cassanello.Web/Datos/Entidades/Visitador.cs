using System.Collections.Generic;

namespace Cassanello.Web.Datos.Entidades
{
    public class Visitador
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Cliente> Clientes { get; set; }







    }
}
