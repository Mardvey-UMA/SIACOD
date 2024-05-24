using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
//using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;
using Telephone;

namespace SSU.ThreeLayer.DAL
{
    public class BaseTelephoneGuide : IBaseTelephoneGuide
    {
        private List<TelephoneGuide> tGuide;

        public BaseTelephoneGuide()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("input.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) // файл пуст, создаем новую базу
            {
                tGuide = new List<TelephoneGuide>();
            }
            else // иначе выполняем десериализацию
            {
                tGuide = (List<TelephoneGuide>)formatter.Deserialize(f);
            }
            f.Close();
        }

        ~BaseTelephoneGuide()
        {
            SaveTelephoneGuide();
        }

        public void AddPerson(Person persons)
        {
            tGuide.Add(persons);
        }

        public void DeletePerson(string name)
        {
            tGuide.RemoveAll(p => p.number == name);
        }

        public IEnumerable<TelephoneGuide> GetAllPerson()
        {
            return tGuide;
        }

        public TelephoneGuide GetPerson(string name)
        {
            return tGuide.FirstOrDefault(p => p.number == name);
        }

        public IEnumerable<TelephoneGuide> FindPeopleBySurname(string surname)
        {
            //
        }

        private void SaveTelephoneGuide()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("input.dat", FileMode.Create))
            {
                formatter.Serialize(f, tGuide);
            }
        }
    }
}