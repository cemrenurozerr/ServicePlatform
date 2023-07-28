using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// Adres Ekle
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("InsertAddress")]
        public IActionResult InsertAddress(AddressDto address)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Address
                {
                    IlId = address.IlId,
                    IlceId = address.IlceId,
                    MahalleId = address.MahalleId
                   
                };
                context.Addresses.Add(entity);
                context.SaveChanges();
            }


            return Ok();
        }

        /// <summary>
        /// Adres Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAddress")]
        public IActionResult DeleteAddress(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Address { Id = id };


                context.Addresses.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre Adres Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAddressById")]
        public IActionResult GetAddressById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Addresses.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }


        /// <summary>
        /// Bütün Adresleri Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAddresses")]
        public IActionResult GetAllAddresses()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Addresses.ToList();
                return Ok(list);
            }
        }
    }
}
