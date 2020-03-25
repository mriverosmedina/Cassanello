using System;
using System.Collections.Generic;
using System.Text;

namespace Cassanello.Common.Models
{
    public class VisitadorResponse
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ducument { get; set; }

        public string NroTelefono { get; set; }

        public ICollection<MedicoResponse> Medicos { get; set; }

    }
}
