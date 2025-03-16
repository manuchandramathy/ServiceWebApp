using System.Data;
using Azure.Core;
using BLServiceWebapp.BLservice;
using Microsoft.AspNetCore.Mvc;
using ServiceCommon.Request;

namespace ServiceWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : Controller
    {
        private readonly BLServiceOrder _blServiceOrder;

        public OrderServiceController(BLServiceOrder blServiceOrder)
        {
            _blServiceOrder = blServiceOrder;
        }
        [HttpPost]
        [Route("LastOrder")]
        public IActionResult SelectOrderDetails([FromBody] DataTable dtrequest)
        {
            //var customer = _blServiceOrder.GetCustomerByEmailAndId(request.User, request.CustomerId);
            //if (customer == null)
            //{
            //    return BadRequest("Invalid email or customer ID.");
            //}

            var order = _blServiceOrder.SelectOrderDetails(dtrequest);
            if (order == null)
            {
                return Ok(new { order = (object)null });
            }

            return Ok(new { order });
        }
    }
}
