using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ProductOverviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public string Code { get; set; }
        public ProductOverviewDto(int id, string name, string image, float price,string code)
        {
            this.Id = id;
            this.Name = name;
            this.Image = image;
            this.Price = price;
            this.Code = code;
        }
    }
}
