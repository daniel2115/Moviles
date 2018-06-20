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
    public class TagController : ApiController
    {
        public string ViewRouteName { get; set; }

        [HttpGet]
        [Route("api/tags")]
        public IHttpActionResult GetTag()
        {
            try
            {
                TagManager manager = new TagManager();
                List<Tag> lista = manager.Obtener();
                return Ok(lista);
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/tags/{id:int}")]
        public IHttpActionResult GetTag(int id)
        {
            try
            {
                TagManager manager = new TagManager();
                var tag = manager.Obtener(id);
                if (tag != null)
                    return Ok(tag);
                else
                    return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/tags")]
        public IHttpActionResult PostTag([FromBody]Tag tag)
        {
            try{
                TagManager manager = new TagManager();
                Tag result = manager.Insertar(tag);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = tag.Id })), tag);
                else return BadRequest();
             }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/tags/{id:int}")]
        public IHttpActionResult PutTag(int id, [FromBody]Tag tag)
        {
             try{
                TagManager manager = new TagManager();
                Tag result = manager.Editar(id, tag);
                if (result != null)
                    return Ok(result);
                else return BadRequest();
             }catch(Exception e){
                return NotFound();
            }
        }

        //SpecTag:

        [HttpGet]
        [Route("api/tags/{id:int}/spectags")]
        public IHttpActionResult GetSpecTag(int id)
        {
            try
            {
                TagManager manager = new TagManager();
                List<SpecialistTag> lista = manager.SpecialistTags(id);
                return Ok(lista);
            }catch (Exception e)
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("api/tags/{id:int}/spectags")]
        public IHttpActionResult PostSpecTag(int id,[FromBody]SpecialistTag spectag)
        {
            try{
                SpecialistTagManager manager = new SpecialistTagManager();
                spectag.TagId = id;
                SpecialistTag result = manager.Insertar(spectag);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = spectag.TagId })), spectag);
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }


        [HttpPut]
        [Route("api/tags/{id:int}/spectags/{spectagid:int}")]
        public IHttpActionResult PutSpecTag(int id,int spectagid, [FromBody]SpecialistTag esp)
        {
            try{
                SpecialistTagManager manager = new SpecialistTagManager();
                SpecialistTag temp = manager.Obtener(spectagid);
                if(temp.TagId == id){
                    SpecialistTag result = manager.Editar(spectagid, esp.TagId);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }else{
                    return NotFound();
                }
            }catch(Exception e){
                return NotFound();
            }
        }



    }
}
