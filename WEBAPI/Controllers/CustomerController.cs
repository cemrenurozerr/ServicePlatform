using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicePlatform.Data.Dtos;
using ServicePlatform.Data.Models;
using System.Numerics;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Müşteri Ekle
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("InsertCustomer")]
        public IActionResult InsertCustomer(CustomerDto customer)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Customer
                {
                    Name = customer.Name,
                    LastName=customer.LastName,
                    Email = customer.Email,
                    Password = customer.Password,
                    Phone=customer.Phone,
                    RoleId = customer.RoleId,
                    AddressId = customer.AddressId


                };
                context.Customers.Add(entity);
                context.SaveChanges();
            }
            

            return Ok();
        }


        /// <summary>
        /// Müşteri Sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            using (var context = new PlatformDbContext())
            {
                var entity = new Customer { Id = id };


                context.Customers.Remove(entity);
                context.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// Id'ye Göre Müşteri Getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {

            using (var context = new PlatformDbContext())
            {

                var model = context.Customers.FirstOrDefault(x => x.Id == id);
                return Ok(model);
            }

        }

        /// <summary>
        /// Bütün Müşterileri Getir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {

            using (var context = new PlatformDbContext())
            {

                var list = context.Customers.ToList();
                return Ok(list);
            }

        }
    }
}
