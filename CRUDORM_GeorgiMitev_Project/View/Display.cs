using CRUDORM_GeorgiMitev_Project.Controller;
using CRUDORM_GeorgiMitev_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_GeorgiMitev_Project.View
{
    internal class Display
    {
        private AnimalController animalLogic = new AnimalController();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Menu" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;

                    case 2:
                        Add();
                        break;

                    case 3:
                        Update();
                        break;

                    case 4:
                        Fetch();
                        break;

                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperation);
        }

        private void PrintAnimal(Animal animal)
        {
            Console.WriteLine($"{animal.Id}. {animal.Name}, Description: {animal.Description}, Price: {animal.Price}, Age: {animal.Age}, Type: {animal.AnimalType.Name}");
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            AnimalController animalController = new AnimalController();
            Animal animal = animalController.Get(id);
            if (animal != null)
            {
                animalController.Delete(id);
            }

            Console.WriteLine($"Successfully deleted!");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            AnimalController animalController = new AnimalController();
            Animal animal = animalController.Get(id);
            if (animal != null)
            {
                PrintAnimal(animal);
            }
        }
        

        private void Update()
        {
            Console.Write("Enter the Animal's id: ");
            int animalId = int.Parse(Console.ReadLine());
            Animal newAnimal = animalLogic.Get(animalId);
            if (newAnimal == null)
            {
                Console.WriteLine("No searching animal");
                return;
            }
            PrintAnimal(newAnimal);
            Console.WriteLine("Enter the new values: ");
            Console.Write("Name: ");
            newAnimal.Name = Console.ReadLine();
            Console.Write("Description: ");
            newAnimal.Description = Console.ReadLine();
            Console.Write("Price: ");
            newAnimal.Price = int.Parse(Console.ReadLine());
            Console.Write("Age: ");
            newAnimal.Age = int.Parse(Console.ReadLine());

            AnimalTypesController animalTypesController = new AnimalTypesController();
            List<AnimalTypes> allAnimalTypes = animalTypesController.GetAllTypes();
            Console.WriteLine("Types: ");
            Console.WriteLine(new string('-', 8));
            foreach (var item in allAnimalTypes)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Choose type by ID: ");
            newAnimal.AnimalTypeId = int.Parse(Console.ReadLine());


            Console.WriteLine($"Successfully updated!");

            AnimalController animalController = new AnimalController();
            animalController.Update(animalId, newAnimal);
        }

        private void Add()
        {
            Animal newAnimal = new Animal();
            Console.Write("Name: ");
            newAnimal.Name = Console.ReadLine();
            Console.Write("Description: ");
            newAnimal.Description = Console.ReadLine();
            Console.Write("Price: ");
            newAnimal.Price = int.Parse(Console.ReadLine());
            Console.Write("Age: ");
            newAnimal.Age = int.Parse(Console.ReadLine());

            AnimalTypesController animalTypesController = new AnimalTypesController();
            List<AnimalTypes> allAnimalTypes = animalTypesController.GetAllTypes();
            Console.WriteLine("Types: ");
            Console.WriteLine(new string('-', 8));
            foreach (var item in allAnimalTypes)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Choose type by ID: ");
            newAnimal.AnimalTypeId = int.Parse(Console.ReadLine());
            Console.WriteLine($"Successfully added!");

            AnimalController animalController = new AnimalController();
            animalController.Create(newAnimal);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Animals" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            AnimalController animalController = new AnimalController();
            var animals = animalController.GetAll();
            foreach (var item in animals)
            {
                Console.WriteLine($"{item.Id}. {item.Name}, Description: {item.Description}, Price: {item.Price}, Age: {item.Age}, Type: {item.AnimalType.Name}");
            }
        }
    }
}
