using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Datos.Entidades
{
    public class TipoVisita
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Visita")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public ICollection<Historico> Historicos { get; set; }

    }
}
