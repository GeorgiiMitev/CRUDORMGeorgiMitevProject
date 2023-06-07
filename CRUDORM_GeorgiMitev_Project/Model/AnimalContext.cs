using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_GeorgiMitev_Project.Model
{
    public class AnimalContext : DbContext
    {
        public AnimalContext() : base("AnimalContext")
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalTypes> AnimalTypes { get; set; }    
    }
}
