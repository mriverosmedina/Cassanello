using System;
using System.Collections.Generic;
using System.Text;

namespace Cassanello.Common.Models
{
    public class MedicoResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime Aniversario { get; set; }

        public string Comentario { get; set; }

        public string Especialidad { get; set; }

        public ICollection<HistoricoResponse> Historicos { get; set; }


    }
}
