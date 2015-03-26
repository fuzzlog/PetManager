using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetManager.Managers;
using PetManager.Models;

namespace PetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelManager mgr = new ModelManager();

            //The first endpoint will accept any number of pet ids as a parameter and return each animals  data in a JSON results array.
            List<int> intList = new List<int>
            {
                1,2,3,4,5,6,7,8,9
            };

            string result = mgr.GetPetsByIdsList(intList);

            Console.WriteLine(result);
            Console.WriteLine("\n");

            //The 2nd endpoint will accept any number of status' and return all animals that are applicable.
            var statusList = new List<PetStatus> { PetStatus.JustArrived, PetStatus.Deployed };
            string result2 = mgr.GetPetsByStatus(statusList);

            Console.WriteLine(result2);
            Console.WriteLine("\n");

            //The third endpoint will allow for creation of a new record.
            var newAnimal = new Animal
            {
                    AnimalsID = 3,
                    City = "New York",
                    Located = DateTime.Now,
                    Moniker = "Pookie",
                    AnimalStatusID = 6
            };

            string result3 = mgr.SaveNewPet(newAnimal);
            Console.WriteLine(result3);
            Console.ReadLine();
        }
    }
}
