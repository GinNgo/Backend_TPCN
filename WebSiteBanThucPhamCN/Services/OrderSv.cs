using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;


namespace WebSiteBanThucPhamCN.Services
{
    public class OrderSv
    {
        OrderDb orderDb = new OrderDb();
        public int CreateOrder(TblOrder orderDetail)
        {
            return orderDb.CreateOrder(orderDetail);
        }
        public List<TblOrder> GetOrderForDashBoard()
        {
            return orderDb.GetOrderForDashBoard();
        }
        public long GetNumberProduct()
        {

            return orderDb.GetNumberProduct();

        }
        public double GetNumberPrice()
        {
            return orderDb.GetNumberPrice();

        }
        public List<DayOrder> GetOnSeven()
        {
            return orderDb.GetOnSeven();
        }
        public List<DayOrder> GetOnMonth()
        {
            return orderDb.GetOnMonth();
        }
        public List<ProductSold> getProductSold()
        {
            return orderDb.getProductSold();
        }
            public List<MonthOrder> GetOnYear()
        {
            return orderDb.GetOnYear();
        }
            public int GetNumberOrder()
        { 
        return orderDb.GetNumberOrder(); 
        }
            public bool CreateOrderDetail(TblOrderDetail orderDetail)
        {
            return orderDb.CreateOrderDetail(orderDetail);
        }

        public List<TblOrder> GetOrderByUserId(int UserId)
        {
            return orderDb.GetOrderByUserId(UserId);
        }
        public TblOrder GetOrderByOrderId(int OrderId)
        {
            return orderDb.GetOrderByOrderId(OrderId);
        }
        public List<TblOrderDetail> GetOrderDetailByOrderId(int OrderId)
        {
            return orderDb.GetOrderDetailByOrderId(OrderId);
        }

        public bool Put(TblOrder Order)
        {
            return orderDb.Put(Order);
        }
        public bool DeleteOrderByOrderId(int OrderId)
        {
            return (orderDb.DeleteOrderByOrderId(OrderId));
        }
      

    }
    
}
