using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cassanello.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboEspecialidades();

        IEnumerable<SelectListItem> GetComboServiceTypes();


    }
}