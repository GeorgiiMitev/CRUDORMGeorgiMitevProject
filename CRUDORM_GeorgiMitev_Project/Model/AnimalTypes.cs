using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_GeorgiMitev_Project.Model
{
    public class AnimalTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Animal> Animals { get; set; }
    }
}
