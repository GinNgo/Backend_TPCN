using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebSiteBanThucPhamCN.Models
{
    public partial class TblProMappingCat
    {
        public int MappingId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
