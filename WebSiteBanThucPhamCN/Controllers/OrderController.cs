using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;


namespace WebSiteBanThucPhamCN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        OrderSv orderSv = new OrderSv();

        [HttpGet("getOrderByUserId/{UserId}")]
        public List<TblOrder> GetOrderByUserId(int UserId)
        {
            return orderSv.GetOrderByUserId(UserId);
        }

        [HttpGet("getOrderForDashBoard")]
        public List<TblOrder> GetOrderForDashBoard()
        {
            List<TblOrder> orders = new List<TblOrder>();
            orders = orderSv.GetOrderForDashBoard();
            return orders;
        }
        public int GetNumberOrder()
        {
            return orderSv.GetNumberOrder();
        }
        [HttpGet("getNumberProduct")]
        public long GetNumberProduct()
        {

            return orderSv.GetNumberProduct();

        }
        [HttpGet("getNumberPrice")]
        public double GetNumberPrice()
        {
            return orderSv.GetNumberPrice();

        }
        [HttpGet("getProductSold")]
        public List<ProductSold> getProductSold()
        {
            return orderSv.getProductSold();
        }
        [HttpGet("getOnSeven")]
        public List<DayOrder> GetOnSeven()
        {
            return orderSv.GetOnSeven();
        }
        [HttpGet("getOnMonth")]
        public List<DayOrder> GetOnMonth()
        {
            return orderSv.GetOnMonth();
        }
        [HttpGet("getOnYear")]
        public List<MonthOrder> GetOnYear()
        {
            return orderSv.GetOnYear();
        }
        [HttpGet("getOrderByOrderId/{OrderId}")]
        public TblOrder getOrderByOrderId(int OrderId)
        {
            return orderSv.GetOrderByOrderId(OrderId);
        }
        [HttpGet("getOrderDetailByOrderId/{TOrderId}")]
        public List<TblOrderDetail> GetOrderDetailByOrderId(int TOrderId)
        {
            return orderSv.GetOrderDetailByOrderId(TOrderId);
        }

        [HttpPost("createOrder/{order}")]


        public int CreateOrder(TblOrder order)
        {
            return orderSv.CreateOrder(order);
        }

        [HttpPost("createOrderDetail/{orderDetail}")]

        public bool CreateOrderDetail(TblOrderDetail orderDetail)
        {
            return orderSv.CreateOrderDetail(orderDetail);
        }

        [HttpPut("{order}")]
        public bool Put(TblOrder order)
        {
            return orderSv.Put(order);
        }

        [HttpDelete("{OrderId}")]

        public bool DeleteOrderByOrderId(int OrderId)
        {
            return orderSv.DeleteOrderByOrderId(OrderId);
        }



    }
}
