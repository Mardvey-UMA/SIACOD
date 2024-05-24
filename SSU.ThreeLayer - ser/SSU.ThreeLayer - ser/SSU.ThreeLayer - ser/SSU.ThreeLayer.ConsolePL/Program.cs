using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using SSU.ThreeLayer.Entities;
using SSU.ThreeLayer.DAL;
using System;
using Pr18_gl1_6;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Injection (в реальном приложении может быть более сложным)

            IBasePerson PersonRepository = new BasePerson();
            IPersonLogic personLogic = new PersonLogic(PersonRepository);


            // Работа с продуктами
            personLogic.AddPerson(new Applicant("Smith", new DateTime(2000, 5, 10), "Engineering"));
            personLogic.AddPerson(new Student("Johnson", new DateTime(1998, 8, 25), "Mathematics", 2));
            personLogic.AddPerson(new Teacher("Williams", new DateTime(1975, 3, 15), "Computer Science", "Professor", 20));
            personLogic.AddPerson(new Applicant("Inyutkin", new DateTime(2004, 7, 14), "Engineering"));

            ShowPerson(personLogic.GetAllPerson());

            personLogic.DeletePerson("Inyutkin");
            Console.WriteLine("After removal:");
            ShowPerson(personLogic.GetAllPerson());
            // Используем метод FindPeopleByAgeRange
            int minAge = 25;
            int maxAge = 35;
            Console.WriteLine($"\nPeople aged between {minAge} and {maxAge}:\n");
            IEnumerable<Person> peopleInRange = personLogic.FindPeopleByAgeRange(minAge, maxAge);
            ShowPerson(peopleInRange);



            //productService.DeleteProduct("Молоко");

            //Console.WriteLine("\nВсе товары после удаления:");
            //ShowProducts(productService.GetAllProducts());
        }

        static void ShowPerson(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
