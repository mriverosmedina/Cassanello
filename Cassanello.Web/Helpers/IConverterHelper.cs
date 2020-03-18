using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Models;
using System.Threading.Tasks;

namespace Cassanello.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Medico> ToMedicoAsync(MedicoViewModel model, string path, bool isNuevo);

        MedicoViewModel ToMedicoViewModel(Medico medico);
    }
}