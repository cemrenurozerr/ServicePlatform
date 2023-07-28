using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;
using System.Numerics;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        /// <summary>
        /// Usta Ekle
        /// </summary>
        /// <param name="expert"></param>
        /// <returns></returns>
        [HttpPost("InsertExpert")]
        public IActionResult InsertExpert(ExpertDto expert)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Expert
                {
                    Name = expert.Name,
                    LastName = expert.LastName,
                    Email=expert.Email,
                    Password=expert.Password,
                    Phone = expert.Phone,
                    RoleId = expert.RoleId,
                    AddressId= expert.AddressId,
                    ServiceId = expert.ServiceId
                };
                context.Experts.Add(entity);
                context.SaveChanges();
            }


            return Ok();
        }

        /// <summary>
        /// Usta Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteExpert")]
        public IActionResult DeleteExpert(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Expert { Id = id };


                context.Experts.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre Usta Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetExpertById")]
        public IActionResult GetExpertById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Experts.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }


        /// <summary>
        /// Bütün Ustaları Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllExperts")]
        public IActionResult GetAllExperts()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Experts.ToList();
                return Ok(list);
            }
        }

        }
    }
