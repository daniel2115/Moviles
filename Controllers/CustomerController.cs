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
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServiciosMovilkes.Controllers
{
    public class CustomerController : ApiController
    {
        public string ViewRouteName { get; set; }

        struct  GetCustomers {
            public List<Customer> customers;    
        }
        struct GetFavorites
        {
            public List<Favorite> favorites;
        }

        struct GetProblems
        {
            public List<Problem> problems;
        }
        struct GetQuotations
        {
            public List<Quotation> quotations;
        }
        //Customer:
        [HttpGet]
        [Route("api/customers")]
        public IHttpActionResult GetCustomer()
        {     
            try{
                CustomerManager manager = new CustomerManager();
                List<Customer> lista = manager.Obtener();
                GetCustomers temp;
                temp.customers = lista;
                return Ok(temp);
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
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = result.id })), result);
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
                GetFavorites temp;
                temp.favorites = lista;
                return Ok(temp);
            }catch(Exception e){
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/customers/{id:int}/favorites/{favoriteid:int}")]
        public IHttpActionResult GetUniqueFavorite(int id, int favoriteid)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
                Favorite favorito = manager.Obtener(favoriteid);
                if (favorito.customerId == id)
                    return Ok(favorito);          
                else 
                    return BadRequest();               
            }
            catch (Exception e)
            {
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
                favorite.customerId = id;
                Favorite result = manager.Insertar(favorite);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = result.customerId })), result);
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
                if (temp.customerId == id)
                {
                    favorito.customerId = id;
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
                if (temp.customerId == id)
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
                GetProblems temp;
                temp.problems = lista;
                return Ok(temp);
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
                problem.customerId = id;
                Problem result = manager.Insertar(problem);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = result.customerId })), result);
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
                if (temp.customerId == id)
                {
                    problem.customerId = id;
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
                if (temp.customerId == id)
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

        [HttpGet]
        [Route("api/customers/{id:int}/problems/{problemid:int}")]
        public IHttpActionResult GetUniqueProblem(int id, int problemid)
        {
            try
            {
                ProblemManager manager = new ProblemManager();
                Problem problem = manager.Obtener(problemid);
                if(problem.customerId == 2)
                return Ok(problem);
                else
                return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        //Quotations:
        [HttpPost]
        [Route("api/customers/{id:int}/problems/{problemid:int}/quotations")]
        public IHttpActionResult PostQuotation(int id, int problemid,[FromBody]Quotation quotation)
        {
            try
            {
                QuotationManager manager = new QuotationManager();
                quotation.specialistId = id;
                quotation.problemId = id;
                quotation.state = 0;
                Quotation result = manager.Insertar(quotation);
                if (result != null)
                    return Created(new Uri(Url.Link(ViewRouteName, new { id = result.specialistId })), result);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/customers/{id:int}/problems/{problemid:int}/quotations")]
        public IHttpActionResult GetQuotation(int id, int problemid)
        {
            try
            {
                CustomerManager manager = new CustomerManager();
                List<Quotation> lista = manager.Quotations(problemid);
                GetQuotations temp;
                temp.quotations = lista;
                return Ok(temp);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

    }
}