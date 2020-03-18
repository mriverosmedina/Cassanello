using Cassanello.Web.Datos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cassanello.Web.Models
{
    public class MedicoViewModel : Medico
    {
        public int VisitadorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Especialidad")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a especialidad.")]
        public int EspecialidadId { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        public IEnumerable<SelectListItem> Especialidades { get; set; }
    }
}
