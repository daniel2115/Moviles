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
    public class SpecialistController : ApiController
    {
        public string ViewRouteName { get; set; }

        //Specialist:

        [HttpGet]
        [Route("api/specialists")]
        public IHttpActionResult GetSpecialist()
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                List<Specialist> lista = manager.Obtener();
                return Ok(lista);
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/specialists/{id:int}")]
        public IHttpActionResult GetSpecialist(int id)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                var specialist = manager.Obtener(id);
                if (specialist != null)
                    return Ok(specialist);
                else
                    return NotFound();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/specialists")]
        public IHttpActionResult PostSpecialist([FromBody]Specialist specialist)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                Specialist result = manager.Insertar(specialist);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = specialist.Id })), specialist);
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/specialists/{id:int}")]
        public IHttpActionResult PutSpecialist(int id, [FromBody]Specialist specialist)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                Specialist result = manager.Editar(id, specialist);
                if (result != null)
                    return Ok();
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/specialists/{id:int}")]
        public IHttpActionResult DeleteSpecialist(int id)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                Specialist result = manager.Eliminar(id);
                if (result != null)
                    return Ok();
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/specialists/authentications")]
        public IHttpActionResult PostAuthentication([FromBody]Input obj)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                Specialist result = manager.Authentication(obj);
                if (result != null)
                    return Ok(result);
                else return Unauthorized();
            }catch(Exception e){
                return NotFound();
            }
        }

        //Favorite:

        [HttpGet]
        [Route("api/specialists/{id:int}/favorites")]
        public IHttpActionResult GetFavorite(int id)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                List<Favorite> lista = manager.Favorite(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/specialists/{id:int}/favorites")]
        public IHttpActionResult PostFavorite(int id, [FromBody]Favorite favorite)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                favorite.SpecialistId = id;
                Favorite result = manager.Insertar(favorite);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = favorite.SpecialistId })), favorite);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/specialists/{id:int}/favorites/{favoriteid:int}")]
        public IHttpActionResult PutFavorite(int id, int favoriteid, [FromBody]Favorite favorito)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                Favorite temp = manager.Obtener(favoriteid);
                if (temp.SpecialistId == id)
                {
                    favorito.SpecialistId = id;
                    Favorite result = manager.Editar(favoriteid, favorito);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/specialists/{id:int}/favorites/{favoriteid:int}")]
        public IHttpActionResult DeleteFavorite(int id, int favoriteid)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                Favorite temp = manager.Obtener(favoriteid);
                if (temp.SpecialistId == id)
                {
                    Favorite result = manager.Eliminar(favoriteid);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
 
      
        //SpecialistTag:

        [HttpGet]
        [Route("api/specialists/{id:int}/specialisttags")]
        public IHttpActionResult GetSpecTag(int id)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                List<SpecialistTag> lista = manager.SpecialistTag(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/specialists/{id:int}/specialisttags")]
        public IHttpActionResult PostSpecTag(int id, [FromBody]SpecialistTag spectag)
        { 
            try
            {
                SpecialistTagManager manager = new SpecialistTagManager();
                spectag.SpecialistId = id;
                SpecialistTag result = manager.Insertar(spectag);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = spectag.SpecialistId })), spectag);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/specialists/{id:int}/specialisttags/{specialisttagid:int}")]
        public IHttpActionResult PutSpecTag(int id, int specialisttagid, [FromBody]SpecialistTag esp)
        {
            try
            {
                SpecialistTagManager manager = new SpecialistTagManager();
                SpecialistTag temp = manager.Obtener(specialisttagid);
                if (temp.SpecialistId == id)
                {
                    SpecialistTag result = manager.Editar(specialisttagid, esp);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }
            catch (Exception e) {
                return NotFound();
            }
        }

        //Quotations:

        [HttpGet]
        [Route("api/specialists/{id:int}/quotations")]
        public IHttpActionResult GetQuotation(int id)
        {
            try
            {
                SpecialistManager manager = new SpecialistManager();
                List<Quotation> lista = manager.Quotations(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/specialists/{id:int}/quotations")]
        public IHttpActionResult PostQuotation(int id, [FromBody]Quotation quotation)
        {
            try
            {
                QuotationManager manager = new QuotationManager();
                quotation.SpecialistId = id;
                Quotation result = manager.Insertar(quotation);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = quotation.SpecialistId })), quotation);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/specialists/{id:int}/quotations/{quotationid:int}")]
        public IHttpActionResult PutQuotation(int id, int quotationid, [FromBody]Quotation quotation)
        {
            try
            {
                QuotationManager manager = new QuotationManager();
                Quotation temp = manager.Obtener(quotationid);
                if (temp.SpecialistId == id)
                {
                    quotation.SpecialistId = id;
                    Quotation result = manager.Editar(quotationid, quotation);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/specialists/{id:int}/quotations/{quotationid:int}")]
        public IHttpActionResult DeleteQuotation(int id, int quotationid)
        {
            try
            {
                QuotationManager manager = new QuotationManager();
                Quotation temp = manager.Obtener(quotationid);
                if (temp.SpecialistId == id)
                {
                    Quotation result = manager.Eliminar(quotationid);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
 


    }
}