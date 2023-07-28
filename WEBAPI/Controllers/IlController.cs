using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlController : ControllerBase
    {
        /// <summary>
        /// İl Ekle
        /// </summary>
        /// <param name="il"></param>
        /// <returns></returns>
        [HttpPost("InsertIl")]
        public IActionResult InsertIl(IlDto il)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Il
                {
                    Name = il.Name
                };
                context.Ils.Add(entity);
                context.SaveChanges();
            }


            return Ok();
        }

        /// <summary>
        /// İl Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteIl")]
        public IActionResult DeleteIl(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Il { Id = id };


                context.Ils.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre İl Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetIlById")]
        public IActionResult GetIlById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Ils.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }

        /// <summary>
        /// Bütün İlleri Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllIls")]
        public IActionResult GetAllIls()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Ils.ToList();
                return Ok(list);
            }
        }
    }
}
