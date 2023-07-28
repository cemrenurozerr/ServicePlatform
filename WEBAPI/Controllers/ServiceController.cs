using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        /// <summary>
        /// Hizmet Alanı Ekle
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("InsertService")]
        public IActionResult InsertService(ServiceDto service)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Service
                {
                    Name = service.Name
                };
                context.Services.Add(entity);
                context.SaveChanges();
            }


            return Ok();
        }

        /// <summary>
        /// Hizmet Alanı Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteService")]
        public IActionResult DeleteService(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Service { Id = id };


                context.Services.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre Hizmet Alanı Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetServiceById")]
        public IActionResult GetServiceById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Services.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }

        /// <summary>
        /// Bütün Hizmet Alanlarını Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllServices")]
        public IActionResult GetAllServices()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Services.ToList();
                return Ok(list);
            }
        }
    }
}
