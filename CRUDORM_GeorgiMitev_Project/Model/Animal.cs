using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_GeorgiMitev_Project.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Age { get; set; }
        public int AnimalTypeId { get; set; } 
        public AnimalTypes AnimalType { get; set; } // M : 1
    }
}
