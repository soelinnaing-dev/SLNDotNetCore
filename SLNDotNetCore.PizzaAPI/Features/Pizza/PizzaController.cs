using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SLNDotNetCore.PizzaAPI.Features.Pizza.Query;
using SLNDotNetCore.PizzaAPI.Models;
using SLNDotNetCore.Shared;
using System.Data;
using System.Data.SqlTypes;
using System.Security.AccessControl;

namespace SLNDotNetCore.PizzaAPI.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContex _db;
        private readonly DapperService _dapperService;

        public PizzaController()
        {
            _db = new AppDbContex();
            _dapperService = new(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetPizza()
        {
            var lst = await _db.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extra")]
        public async Task<IActionResult>GetExtra()
        {
            var list = await _db.Extras.ToListAsync();
            return Ok(list);
        }

        //[HttpGet("order/{invoiceNo}")]
        //public async Task<IActionResult> GetOrder(string invoiceNo)
        //{
        //    var item = await _db.PizzasOrder.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
        //    var lst = await _db.PizzasOrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
        //    return Ok(new
        //    {
        //        Order = item,
        //        OrderDetails = lst
        //    });        
        //}

        [HttpGet("order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<OrderInvoiceHead>
                (
                    PizzaQuery.orderquery,
                    new { PizzaOrderInvoiceNo = invoiceNo }
                );
            var lst = _dapperService.Query<OrderInvoiceDetails>
                (
                    PizzaQuery.detailsQuery,
                    new {PizzaOrderInvoiceNo=invoiceNo}
                );
            var model = new OrderInvoiceHeadDetailResponse
            {
                order = item,
                orderDetails = lst,
            };
            return Ok(model);
        }

        [HttpPost("pizzaorder")]
        public async Task<IActionResult> PizzaOrder(RequestOrder requestOrder)
        {
            var itemPizza = await _db.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == requestOrder.PizzaId);
            var pizzaPrice = itemPizza.Price;

            if (requestOrder.extra.Length > 0)
            {
                var extraList = await _db.Extras.Where(x => requestOrder.extra.Contains(x.ExtraId)).ToListAsync();
                pizzaPrice += extraList.Sum(x => x.ExtraPrice);
            }
            var invoiceNo = DateTime.Now.ToString("ddMMyyyyHHmmss");
            PizzaOrder order = new PizzaOrder()
            {
                PizzaOrderInvoiceNo = invoiceNo,
                PizzaId = requestOrder.PizzaId,
                TotalAmount = pizzaPrice
            };
            List<PizzaOrderDetails> detail = requestOrder.extra.Select(extraId => new PizzaOrderDetails
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo=invoiceNo,
            }).ToList();
            await _db.AddAsync(order);
            await _db.AddRangeAsync(detail);
            await _db.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                invoiceNo = invoiceNo,
                Message = "Thank you for your order..",
                TotalAmount = pizzaPrice,
            };
            return Ok(response);
        }
    }
}
