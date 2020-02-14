using System.ComponentModel.DataAnnotations;

namespace Cassanello.Web.Datos.Entidades
{
    public class Laboratorio
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Codigo { get; set; }

        [Display(Name = "Laboratorio")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Descripcion { get; set; }
    }
}
