using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebSiteBanThucPhamCN.Models
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double PriceDiscount { get; set; }
        public int BrandId { get; set; }
        public string Origin { get; set; }
        public int CategoryId { get; set; }
        public bool? Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
