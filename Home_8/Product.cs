using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_8
{
    public class Product
    {
        public string? ProductName { get; set; }
        
        public int NumberOfKCalories { get; set; }

        public Product()
        {
            Random random = new Random();
            NumberOfKCalories = random.Next(1, 500);
            ProductName = Home_3.Program.GenerateName(6);
        }
    }
}
