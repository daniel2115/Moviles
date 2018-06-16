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
    public class DocumentTypeController : ApiController
    {
        public string ViewRouteName { get; set; }

        //DocumentType:

        [HttpGet]
        [Route("api/documenttypes")]
        public IHttpActionResult GetDocumentType()
        {
            try{
                DocumentTypeManager manager = new DocumentTypeManager();
                List<DocumentType> lista = manager.Obtener();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/documenttypes/{id:int}")]
        public IHttpActionResult GetDocumentType(int id)
        {
            try{
                DocumentTypeManager manager = new DocumentTypeManager();
                var tag = manager.Obtener(id);
                if (tag != null)
                    return Ok(tag);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        //Specialists:

        [HttpGet]
        [Route("api/documenttypes/{id:int}/specialists")]
        public IHttpActionResult GetSpecialist(int id)
        {
            try
            {
                DocumentTypeManager manager = new DocumentTypeManager();
                List<Specialist> lista = manager.Specialist(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        //Customers:

        [HttpGet]
        [Route("api/documenttypes/{id:int}/customers")]
        public IHttpActionResult GetCustomer(int id)
        {
            try
            {
                DocumentTypeManager manager = new DocumentTypeManager();
                List<Customer> lista = manager.Customer(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


    }
}
