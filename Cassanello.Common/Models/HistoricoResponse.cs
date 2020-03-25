using System;
using System.Collections.Generic;
using System.Text;

namespace Cassanello.Common.Models
{
    public class HistoricoResponse
    {
        public int Id { get; set; }

        public string TipoVisita { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Comentario { get; set; }
    }
}
