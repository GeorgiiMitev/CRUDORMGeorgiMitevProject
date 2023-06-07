using CRUDORM_GeorgiMitev_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_GeorgiMitev_Project.Controller
{
    public class AnimalController
    {
        private AnimalContext _animalContext = new AnimalContext();

        public Animal Get(int id)
        {
            Animal animal = _animalContext.Animals.Find(id);
            if (animal != null)
            {
                _animalContext.Entry(animal).Reference(x => x.AnimalType).Load();
            }
            return animal;
        }

        public List<Animal> GetAll()
        {
            return _animalContext.Animals.Include("AnimalTypes").ToList();
        }

        public void Create(Animal product)
        {
            _animalContext.Animals.Add(product);
            _animalContext.SaveChanges();
        }

        public void Update(int id, Animal product)
        {
            Animal animal = _animalContext.Animals.Find(id);
            if (animal == null)
            {
                return;
            }
            animal.Name = product.Name;
            animal.Description = product.Description;
            animal.Price = product.Price;
            animal.Age = product.Age;
            animal.AnimalType = product.AnimalType;


            _animalContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Animal animal = _animalContext.Animals.Find(id);
            _animalContext.Animals.Remove(animal);
            _animalContext.SaveChanges();
        }
    }
}


