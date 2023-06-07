using CRUDORM_GeorgiMitev_Project.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_GeorgiMitev_Project.Controller
{
    public class AnimalTypesController
    {
        private AnimalContext _animalcontext = new AnimalContext(); // DB

    // used for ComboBox when adding/updating something in the table
    public List<AnimalTypes> GetAllTypes()
    {
    return _animalcontext.AnimalTypes.ToList();
     }
    // a method used for finding the Type by Id
    public string GetTypeById(int id)
    {
         return _animalcontext.AnimalTypes.Find(id).Name;
    }
    }
}
