using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlceController : ControllerBase
    {
        /// <summary>
        /// İlçe ekle
        /// </summary>
        /// <param name="ilce"></param>
        /// <returns></returns>
        [HttpPost("InsertIlce")]
        public IActionResult InsertIlce(IlceDto ilce)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Ilce
                {
                    Name = ilce.Name
                };
                context.Ilces.Add(entity);
                context.SaveChanges();
            }


            return Ok();
        }

        /// <summary>
        /// İlçe Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteIlce")]
        public IActionResult DeleteIlce(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Ilce { Id = id };


                context.Ilces.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre İlçe Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetIlceById")]
        public IActionResult GetIlceById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Ilces.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }

        /// <summary>
        /// Bütün İlçeleri Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllIlces")]
        public IActionResult GetAllIlces()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Ilces.ToList();
                return Ok(list);
            }
        }
    }
}
