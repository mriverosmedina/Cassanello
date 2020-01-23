using System.ComponentModel.DataAnnotations;

namespace Cassanello.Web.Datos.Entidades
{
    public class Visitador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage ="El {0} no puede ingresar mas de {1} caracteres.")]
        [Display(Name ="Nombre")]
        public string NomVisitador { get; set; }        

        [MaxLength(20, ErrorMessage = "El {0} no puede ingresar mas de {1} caracteres.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }        
       
        public int Laboratorio { get; set; }

        //public string NomCompleto => $"{NomVisitador} {ApeVisitador}";     


    }
}
