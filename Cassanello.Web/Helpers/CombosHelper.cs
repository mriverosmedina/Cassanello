using Cassanello.Web.Datos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboEspecialidades()
        {
            var list = _dataContext.Especialidades.Select(es => new SelectListItem
            {
                Text = es.Descripcion,
                Value = $"{es.Id}"
            }).OrderBy(es => es.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione especialidad...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContext.Especialidades.Select(es => new SelectListItem
            {
                Text = es.Descripcion,
                Value = $"{es.Id}"
            }).OrderBy(es => es.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione servicios...]",
                Value = "0"
            });
            return list;
        }
    }
}
