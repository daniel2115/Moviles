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
    public class FavoriteController : ApiController
    {
        public string ViewRouteName { get; set; }

        //Favorite:

        [HttpGet]
        [Route("api/favorites")]
        public IHttpActionResult GetFavorite()
        {
            try{
                FavoriteManager manager = new FavoriteManager();
                List<Favorite> lista = manager.Obtener();
                return Ok(lista);
            }catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/favorites/{id:int}")]
        public IHttpActionResult GetFavorite(int id)
        {
            try
            {
                FavoriteManager manager = new FavoriteManager();
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
