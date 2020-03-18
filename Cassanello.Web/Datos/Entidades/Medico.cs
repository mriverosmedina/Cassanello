using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cassanello.Web.Datos.Entidades
{
    public class Medico
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Registro")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Registro { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Aniversario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Aniversario { get; set; }

        [MaxLength(50, ErrorMessage = "El {0} campo no puedo tener mas de {1} caracteres.")]
        public string Direccion { get; set; }

        [MaxLength(50, ErrorMessage = "El {0} campo no puedo tener mas de {1} caracteres.")]
        public string Lugar { get; set; }

        [MaxLength(255, ErrorMessage = "El {0} campo no puedo tener mas de {1} caracteres.")]
        public string Remarks { get; set; }

        //TODO: replace the correct URL for the image
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://TDB.azurewebsites.net{ImageUrl.Substring(1)}";

        [Display(Name = "Nacimiento Local")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd")]
        public DateTime BornLocal => Aniversario.ToLocalTime();

        public Visitador Visitador { get; set; }

        public Especialidad Especialidad { get; set; }

        public ICollection<Historico> Historicos { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
