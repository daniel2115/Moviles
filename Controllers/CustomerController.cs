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
    public class CustomerController : ApiController
    {
        public string ViewRouteName { get; set; }

        //Customer:

        [HttpGet]
        [Route("api/customers")]
        public IHttpActionResult GetCustomer()
        {     
            try{
                CustomerManager manager = new CustomerManager();
                List<Customer> lista = manager.Obtener();
                return Ok(lista);
            }catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/customers/{id:int}")]
        public IHttpActionResult GetCustomer(int id)
        {
             try{
                CustomerManager manager = new CustomerManager();
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

        [HttpPost]
        [Route("api/customers")]
        public IHttpActionResult PostCustomer([FromBody]Customer client)
        {
            try
            {
                CustomerManager manager = new CustomerManager();
                Customer result = manager.Insertar(client);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = client.Id })), client);
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/customers/{id:int}")]
        public IHttpActionResult PutCustomer(int id, [FromBody]Customer client)
        {
            try{
                CustomerManager manager = new CustomerManager();
                Customer result = manager.Editar(id, client);
                if (result != null)
                    return Ok();
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/customers/{id:int}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try{
                CustomerManager manager = new CustomerManager();
                Customer result = manager.Eliminar(id);
                if (result != null)
                    return Ok();
                else return BadRequest();
            }catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/customers/authentications")]
        public IHttpActionResult PostAuthentication([FromBody]Input obj)
        {
            try{
                CustomerManager manager = new CustomerManager();
                Customer result = manager.Authentication(obj);
                if (result != null)
                    return Ok(result);
                else return Unauthorized();
            }catch (Exception e)
            {
                return NotFound();
            }
        }

        //Favorite:

        [HttpGet]
        [Route("api/customers/{id:int}/favorites")]
        public IHttpActionResult GetFavorite(int id)
        {
            try
            {
                CustomerManager manager = new CustomerManager();
                List<Favorite> lista = manager.Favorite(id);
                return Ok(lista);
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/customers/{id:int}/favorites")]
        public IHttpActionResult PostFavorite(int id,[FromBody]Favorite favorite)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                favorite.CustomerId = id;
                Favorite result = manager.Insertar(favorite);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = favorite.CustomerId })), favorite);
                else return BadRequest();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/customers/{id:int}/favorites/{favoriteid:int}")]
        public IHttpActionResult PutFavorite(int id, int favoriteid, [FromBody]Favorite favorito)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                Favorite temp = manager.Obtener(favoriteid);
                if (temp.CustomerId == id)
                {
                    favorito.CustomerId = id;
                    Favorite result = manager.Editar(favoriteid, favorito);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/customers/{id:int}/favorites/{favoriteid:int}")]
        public IHttpActionResult DeleteFavorite(int id, int favoriteid)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                Favorite temp = manager.Obtener(favoriteid);
                if (temp.CustomerId == id)
                {
                    Favorite result = manager.Eliminar(favoriteid);
                    if (result != null)
                        return Ok();
                    else return BadRequest();
                }
                else return NotFound();
            }catch(Exception e){
                return NotFound();
            }
        }

        //Problems:

        [HttpGet]
        [Route("api/customers/{id:int}/problems")]
        public IHttpActionResult GetProblem(int id)
        {
            try
            {
                CustomerManager manager = new CustomerManager();
                List<Problem> lista = manager.Problem(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/customers/{id:int}/problems")]
        public IHttpActionResult PostProblem(int id, [FromBody]Problem problem)
        {
            try
            {
                ProblemManager manager = new ProblemManager();
                problem.CustomerId = id;
                Problem result = manager.Insertar(problem);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = problem.CustomerId })), problem);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/customers/{id:int}/problems/{problemid:int}")]
        public IHttpActionResult PutProblem(int id, int problemid, [FromBody]Problem problem)
        {
            try
            {
                ProblemManager manager = new ProblemManager();
                Problem temp = manager.Obtener(problemid);
                if (temp.CustomerId == id)
                {
                    problem.CustomerId = id;
                    Problem result = manager.Editar(problemid, problem);
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
        [Route("api/customers/{id:int}/problems/{problemid:int}")]
        public IHttpActionResult DeleteProblem(int id, int problemid)
        {
            try
            {
                ProblemManager manager = new ProblemManager();
                Problem temp = manager.Obtener(problemid);
                if (temp.CustomerId == id)
                {
                    Problem result = manager.Eliminar(problemid);
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