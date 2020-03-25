using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cassanello.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
    }
}
