using Cassanello.Web.Datos;
using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }


        public async Task<Medico> ToMedicoAsync(MedicoViewModel model, string path, bool isNuevo)
        {
            var medico = new Medico
            {
                Agendas = model.Agendas,
                Registro = model.Registro,
                Aniversario = model.Aniversario,
                Historicos = model.Historicos,
                Direccion = model.Direccion,
                Lugar = model.Lugar,
                Id = isNuevo ? 0 : model.Id,
                ImageUrl = path.Trim(),
                Name = model.Name.Trim(),
                Visitador = await _dataContext.Visitadores.FindAsync(model.VisitadorId),
                Especialidad = await _dataContext.Especialidades.FindAsync(model.EspecialidadId),
                Remarks = model.Remarks
            };

            return medico;
        }

        public MedicoViewModel ToMedicoViewModel(Medico medico)
        {
            return new MedicoViewModel
            {
                Agendas = medico.Agendas,
                Registro = medico.Registro,
                Aniversario = medico.Aniversario,
                Historicos = medico.Historicos,
                ImageUrl = medico.ImageUrl,
                Name = medico.Name.Trim(),
                Visitador = medico.Visitador,
                Especialidad = medico.Especialidad,
                Remarks = medico.Remarks,
                Id = medico.Id,
                VisitadorId = medico.Visitador.Id,
                EspecialidadId = medico.Especialidad.Id,
                Especialidades = _combosHelper.GetComboEspecialidades()

            };

        }




    }
}
