using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Data
{
    public class DayOrder
    {
        public int day { get; set; }
        public int value { get; set; }
        public double totalPrice = 0;

    }
    public class MonthOrder
    {
        public int Month { get; set; }
        public int value { get; set; }
        public double totalPrice = 0;

    }

    public class ProductSold
    {
        public int Postition { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Origin { get; set; }
        public int Quantity { get; set; }
        
    }
    public class OrderDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext(); ProductSv productSv = new ProductSv(); BrandSv brandSv = new BrandSv();
        public int CreateOrder(TblOrder order)
        {
            try
            {

                TblOrder tblOrder = new TblOrder();

                tblOrder.CustomerId = order.CustomerId;
                tblOrder.OrderDate = DateTime.Now;
                tblOrder.Total = order.Total;
                tblOrder.Period = order.Period;
                tblOrder.Note = order.Note;
                tblOrder.Status = order.Status;
                tblOrder.IsDeleted = order.IsDeleted;

                context.TblOrder.Add(tblOrder);
                context.SaveChanges();

                return GetOrderId(tblOrder);

            }
            catch (Exception)
            {
                return 0;
            }

        }
        public long GetNumberProduct()
        {


            var catgroup = context.TblOrderDetail.Select(s => s.Quantity).ToList();
            long s = 0;
            catgroup.ForEach(e =>
            {
                s += e;
            });
            return s;

        }
        public double GetNumberPrice()
        {


            var catgroup = context.TblOrder.Select(s => s.Total).ToList();
            double s = 0;
            catgroup.ForEach(e =>
            {
                s += e;
            });
            return s;

        }
        public List<MonthOrder> GetOnYear()
        {



            List<MonthOrder> dayOrders = new List<MonthOrder>();
            for (int i = 1; i <= 12; i++)
            {

                List<TblOrder> tblOrders = new List<TblOrder>();
                tblOrders = context.TblOrder.Where(e => e.OrderDate.Value.Month == i && e.OrderDate.Value.Year == DateTime.Now.Year).ToList();
                MonthOrder dayOrder = new MonthOrder();
                dayOrder.Month = i;
                dayOrder.value = tblOrders.Count;

                if (dayOrders.Count > 0)
                {
                    tblOrders.ForEach(s =>
                    {
                        dayOrder.totalPrice += s.Total;
                    });
                }
                else
                {
                    dayOrder.totalPrice = 0;
                }

                dayOrders.Add(dayOrder);

            }



            return dayOrders;
        }
        public List<DayOrder> GetOnMonth()
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int lastDay = firstDayOfMonth.AddMonths(1).AddDays(-1).Day;
            string dayOfWeek = date.DayOfWeek.ToString();


            List<DayOrder> dayOrders = new List<DayOrder>();
            for (int i = 1; i <= lastDay; i++)
            {

                List<TblOrder> tblOrders = new List<TblOrder>();
                tblOrders = context.TblOrder.Where(e => e.OrderDate.Value.Day == i).ToList();
                DayOrder dayOrder = new DayOrder();
                dayOrder.day = i;
                dayOrder.value = tblOrders.Count;

                if (dayOrders.Count > 0)
                {
                    tblOrders.ForEach(s =>
                    {
                        dayOrder.totalPrice += s.Total;
                    });
                }
                else
                {
                    dayOrder.totalPrice = 0;
                }

                dayOrders.Add(dayOrder);

            }



            return dayOrders;
        }
        public List<DayOrder> GetOnSeven()
        {
            DateTime date = DateTime.Now;

            string dayOfWeek = date.DayOfWeek.ToString();
            if (dayOfWeek.Equals("Monday"))
            {
                date = date.AddDays(6);
            }
            else
            {
                if (dayOfWeek.Equals("Tuesday"))
                {
                    date = date.AddDays(5);
                }
                else
                {
                    if (dayOfWeek.Equals("Wednesday"))
                    {
                        date = date.AddDays(4);
                    }
                    else
                    {
                        if (dayOfWeek.Equals("Thursday"))
                        {
                            date = date.AddDays(3);
                        }
                        else
                        {

                            if (dayOfWeek.Equals("Friday"))
                            {
                                date = date.AddDays(2);
                            }
                            else
                            {
                                if (dayOfWeek.Equals("Saturday"))
                                {
                                    date = date.AddDays(1);
                                }
                            }
                        }
                    }

                }
            }
            int day = date.Day;
            List<DayOrder> dayOrders = new List<DayOrder>();
            for (int i = day - 6; i <= day; i++)
            {

                List<TblOrder> tblOrders = new List<TblOrder>();
                tblOrders = context.TblOrder.Where(e => e.OrderDate.Value.Day == i).ToList();
                DayOrder dayOrder = new DayOrder();
                dayOrder.day = i;
                dayOrder.value = tblOrders.Count;

                if (dayOrders.Count > 0)
                {
                    tblOrders.ForEach(s =>
                    {
                        dayOrder.totalPrice += s.Total;
                    });
                }
                else
                {
                    dayOrder.totalPrice = 0;
                }

                dayOrders.Add(dayOrder);

            }



            return dayOrders;
        }

        public List<TblOrder> GetOrderForDashBoard()
        {
            List<TblOrder> orders = new List<TblOrder>();

            orders = context.TblOrder.Where(e => e.IsDeleted == false && e.Status == true).OrderByDescending(e=>e.OrderDate).ToList();

            return orders;
        }
        public List<ProductSold> getProductSold()
        {
            List<ProductSold> products = new List<ProductSold>();
            var product = context.TblOrderDetail.GroupBy(c =>new { c.ProductId }).
                  Select(g => new
                  {
                      ProductId = g.Key.ProductId,
                      
                      Quantity = g.Sum(s => s.Quantity),
                   

                  }).OrderByDescending(c=>c.Quantity).ToList();
            int i = 1;
            product.ForEach(e =>
            {
                ProductSold productSold = new ProductSold();
                TblProduct tblProduct = new TblProduct();
                TblBrand tblBrand = new TblBrand();
                tblProduct = productSv.GetProductById((e.ProductId));
                tblBrand = brandSv.GetBrandById((tblProduct.BrandId));
                productSold.Postition =i++ ;
                productSold.ProductName=tblProduct.ProductName;
                productSold.Brand = tblBrand.BrandName;
                productSold.Origin=tblProduct.Origin;
                productSold.Quantity = e.Quantity;

                products.Add(productSold);
            });
           
            return products;
        }
        public int GetNumberOrder()
        {
            List<TblOrder> tblOrders = new List<TblOrder>();
            tblOrders = context.TblOrder.ToList();
            int number = tblOrders.Count();
            return number;
        }
        public int GetOrderId(TblOrder order)
        {
            var x = context.TblOrder.Where(e => e.CustomerId.Equals(order.CustomerId) && e.Total == order.Total && e.Status == order.Status && order.OrderDate == e.OrderDate).FirstOrDefault();
            return x.OrderId;
        }
        public bool CreateOrderDetail(TblOrderDetail orderDetail)
        {
            try
            {

                TblOrderDetail tblOrderDetail = new TblOrderDetail();

                tblOrderDetail.OrderId = orderDetail.OrderId;
                tblOrderDetail.ProductId = orderDetail.ProductId;
                tblOrderDetail.Price = orderDetail.Price;
                tblOrderDetail.Quantity = orderDetail.Quantity;

                tblOrderDetail.IsDeleted = orderDetail.IsDeleted;

                context.TblOrderDetail.Add(tblOrderDetail);
                context.SaveChanges();



                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<TblOrder> GetOrderByUserId(int UserId)
        {
            return context.TblOrder.Where(e => e.CustomerId == UserId).ToList();
        }
        public TblOrder GetOrderByOrderId(int OrderId)
        {
            return context.TblOrder.Where(e => e.OrderId == OrderId).FirstOrDefault();
        }
        public List<TblOrderDetail> GetOrderDetailByOrderId(int OrderId)
        {
            return context.TblOrderDetail.Where(e => e.OrderId == OrderId).ToList();
        }

        public bool Put(TblOrder Order)
        {
            try
            {

                TblOrder tblOrder = new TblOrder();
                tblOrder.OrderId = Order.OrderId;
                tblOrder.CustomerId = Order.CustomerId;
                tblOrder.OrderDate = Order.OrderDate;
                tblOrder.Total = Order.Total;
                tblOrder.Period = Order.Period;
                tblOrder.Note = Order.Note;
                tblOrder.IsDeleted = Order.IsDeleted;
                tblOrder.Status = Order.Status;
                context.Entry(tblOrder).State = EntityState.Modified;

                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteOrderByOrderId(int OrderId)
        {
            try
            {
                TblOrder tblOrder = context.TblOrder.Find(OrderId);

                context.Entry(tblOrder).State = EntityState.Deleted;
                context.SaveChanges();

                return DeleteOrderDetailByOrderId(OrderId);

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteOrderDetailByOrderId(int OrderId)
        {
            try
            {
                TblOrderDetail tblOrderDetail = context.TblOrderDetail.Find(OrderId);

                context.Entry(tblOrderDetail).State = EntityState.Deleted;
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
