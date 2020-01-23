using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Datos.Entidades
{
    public class Usuario: IdentityUser
    {
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} no puede ingresar mas de {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }       

    }
}
