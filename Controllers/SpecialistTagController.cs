using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiciosMovilkes.Models;
using ServiciosMovilkes.Manager;
using System.Threading.Tasks;
using System.Threading;

namespace ServiciosMovilkes.Controllers
{
    public class SpecialistTagController : ApiController
    {
        public string ViewRouteName { get; set; }

        //SpecTag:

        [HttpGet]
        [Route("api/specialisttags")]
        public IHttpActionResult GetSpecialistTag()
        {
            try
            {
                SpecialistTagManager manager = new SpecialistTagManager();
                List<SpecialistTag> lista = manager.Obtener();
                    return Ok(lista);
            }catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/specialisttags/{id:int}")]
        public IHttpActionResult GetSpecialistTag(int id)
        {
            try{
                SpecialistTagManager manager = new SpecialistTagManager();
                var specialist = manager.Obtener(id);
                if (specialist != null)
                    return Ok(specialist);
                else
                     return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

    }
}
