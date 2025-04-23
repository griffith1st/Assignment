using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement;
using System.Collections.Generic;

namespace OrderManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return _orderService.GetAllOrders();
        }

        // GET api/orders/{orderNumber}
        [HttpGet("{orderNumber:int}")]
        public ActionResult<Order> GetByNumber(int orderNumber)
        {
            var list = _orderService.QueryByOrderNumber(orderNumber);
            if (list.Count == 0) return NotFound($"订单 {orderNumber} 未找到");
            return list[0];
        }

        // GET api/orders/byProduct?name=手机
        [HttpGet("byProduct")]
        public ActionResult<List<Order>> GetByProduct([FromQuery] string name)
        {
            return _orderService.QueryByProductName(name);
        }

        // GET api/orders/byCustomer?name=张三
        [HttpGet("byCustomer")]
        public ActionResult<List<Order>> GetByCustomer([FromQuery] string name)
        {
            return _orderService.QueryByCustomer(name);
        }

        // GET api/orders/byTotal?amount=10000
        [HttpGet("byTotal")]
        public ActionResult<List<Order>> GetByTotal([FromQuery] double amount)
        {
            return _orderService.QueryByTotalAmount(amount);
        }

        // POST api/orders
        [HttpPost]
        public ActionResult Create([FromBody] Order order)
        {
            try
            {
                _orderService.AddOrder(order);
                return CreatedAtAction(nameof(GetByNumber), new { orderNumber = order.OrderNumber }, order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/orders/{orderNumber}
        [HttpPut("{orderNumber:int}")]
        public ActionResult Update(int orderNumber, [FromBody] Order order)
        {
            if (orderNumber != order.OrderNumber)
                return BadRequest("URL 中的订单号必须与请求体一致");

            try
            {
                _orderService.UpdateOrder(order);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/orders/{orderNumber}
        [HttpDelete("{orderNumber:int}")]
        public ActionResult Delete(int orderNumber)
        {
            try
            {
                _orderService.RemoveOrder(orderNumber);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
