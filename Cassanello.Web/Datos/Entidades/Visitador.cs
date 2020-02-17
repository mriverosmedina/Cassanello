using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cassanello.Web.Datos.Entidades
{
    public class Visitador
    {
        public int Id { get; set; }

        public  Usuario Usuario { get; set; }
        
        public ICollection<Medico> Medicos { get; set; }

        public ICollection<Agenda> Agendas { get; set; }





    }
}
