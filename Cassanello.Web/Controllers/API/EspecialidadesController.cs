using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cassanello.Web.Datos;
using Cassanello.Web.Datos.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Cassanello.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EspecialidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public EspecialidadesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Especialidades
        [HttpGet]
        public IEnumerable<Especialidad> GetEspecialidades()
        {
            return _context.Especialidades;
        }
    }
}