using System.Data;
using DLServiceWebApp.DataService;
using DLServiceWebApp.DataService.Entity;
using ServiceCommon.Response;
namespace BLServiceWebapp.BLservice
{
    /// <summary>
    /// 
    /// </summary>
    public class BLServiceOrder
    {
        private readonly ServiceOrderRepository _orderRepository;

        public BLServiceOrder(ServiceOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// fetch order details and validate user
        /// </summary>
        /// <param name="dtrequest"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<OrderDetails> SelectOrderDetails(DataTable dtrequest)
        {
            if (!dtrequest.Columns.Contains("customerId") || string.IsNullOrEmpty(dtrequest.Rows[0]["customerId"].ToString()))
            {
                throw new ArgumentException("Customer ID cannot be null or empty.", nameof(dtrequest.Rows[0]["customerId"]));
            }

            if (!dtrequest.Columns.Contains("User") || string.IsNullOrEmpty(dtrequest.Rows[0]["User"].ToString()))
            {
                throw new ArgumentException("User cannot be null or empty.", nameof(dtrequest.Rows[0]["User"]));
            }
           
            var customer =  _orderRepository.selectCustomerDetails(dtrequest.Rows[0]["User"], dtrequest.Rows[0]["customerId"]);
            
            if (customer == null)
            {
                return BadRequest("Invalid email or customer ID.");
            }

            var customerId = dtrequest.Rows[0]["customerId"].ToString();

            return await _orderRepository.GetLatestOrderAsync(customerId);
        }
    }
}
