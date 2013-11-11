using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ProductOverviewDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public float price { get; set; }

        public ProductOverviewDto(int id, string name, string image, float price)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.price = price;
        }
    }
}
