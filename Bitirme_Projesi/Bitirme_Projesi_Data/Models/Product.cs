using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
      
        public string ProductName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Explanation { get; set; }

        [ForeignKey("Category Name")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }

        [Required]
        public bool UsingStatus { get; set; }
        public byte Image { get; set; }

        [Required]
        public int Price { get; set; }
        public bool Offer { get; set; } = false;
       

       
    }
}
