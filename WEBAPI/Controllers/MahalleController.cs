using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahalleController : ControllerBase
    {
        /// <summary>
        /// Mahalle Ekle
        /// </summary>
        /// <param name="mahalle"></param>
        /// <returns></returns>
        [HttpPost("InsertMahalle")]
        public IActionResult InsertIl(MahalleDto mahalle)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Mahalle
                {
                    Name = mahalle.Name
                };
                context.Mahalles.Add(entity);
                context.SaveChanges();
            }


            return Ok();
        }

        /// <summary>
        /// Mahalle Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteMahalle")]
        public IActionResult DeleteMahalle(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Mahalle { Id = id };


                context.Mahalles.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre Mahalle Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetMahalleById")]
        public IActionResult GetMahalleById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Mahalles.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }

        /// <summary>
        /// Bütün Mahalleleri Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllMahalles")]
        public IActionResult GetAllMahalles()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Mahalles.ToList();
                return Ok(list);
            }
        }

        
 
    }
}
