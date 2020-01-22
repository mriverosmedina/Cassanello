using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Datos.Entidades
{
    public class Laboratorio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public int CodLaboratorio { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} no puede contener mas de {1} caracteres.")]
        public string NomLaboratorio { get; set; }

        public ICollection<Visitador> Visitadores { get; set; }




    }
}
