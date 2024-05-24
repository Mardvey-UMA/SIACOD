using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.DAL
{
    public class BasePerson : IBasePerson
    {
        private List<Person> person;

        public BasePerson()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("input.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) // файл пуст, создаем новую базу
            {
                person = new List<Person>();
            }
            else // иначе выполняем десериализацию
            {
                person = (List<Person>)formatter.Deserialize(f);
            }
            f.Close();
        }

        ~BasePerson()
        {
            SavePerson();
        }

        public void AddPerson(Person persons)
        {
            person.Add(persons);
        }

        public void DeletePerson(string name)
        {
            person.RemoveAll(p => p.lastName == name);
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return person;
        }

        public Person GetPerson(string name)
        {
            return person.FirstOrDefault(p => p.lastName == name);
        }

        public IEnumerable<Person> FindPeopleByAgeRange(int minAge, int maxAge)
        {
            return person.FindAll(p => p.CalculateAge() >= minAge && p.CalculateAge() <= maxAge);
        }

        private void SavePerson()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("input.dat", FileMode.Create))
            {
                formatter.Serialize(f, person);
            }
        }
    }
}