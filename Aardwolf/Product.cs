using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aardwolf
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string ThumbnailPictureUrl { get; set; }
        public decimal Cost { get; set; }
        
    }
}
