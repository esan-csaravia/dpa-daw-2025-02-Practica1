using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica01._21200159.CORE.Core.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public bool? IsActive { get; set; }

    }
}
