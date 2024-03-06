using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Telephone;
using System.Xml.Linq;

namespace Telephone
{
    class Program
    { 
    static void Print(List<TelephoneGuide> TG)
        {
            if (TG.Count > 0) { 
            Console.WriteLine("--------");
            foreach (var t in TG)
            {
                t.GetInfo();
            }
            Console.WriteLine("--------");
            }
            else
            {
                Console.WriteLine("Нет элементов в списке");
            }
        }

        static void Main(string[] args)
        {
            List<TelephoneGuide> TG = new List<TelephoneGuide>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("C:\\siacode\\SIACOD\\PR18_8\\PR18_8\\input.dat",
             FileMode.OpenOrCreate))
            {
                if (f.Length != 0)
                {
                    TG = (List<TelephoneGuide>)formatter.Deserialize(f);
                }
            }
            Print(TG);


          TG.Add(new Person("Stepanov2", "ul.Pionerov", "10301"));
            /*  
            TG.Add(new Person("Igorev", "ul.Stroiteley", "10001"));
            TG.Add(new Person("Slyagin", "ul.Eremina", "10601"));
            TG.Add(new Person("Pupkin", "ul.Semenova", "10701"));
            TG.Add(new Friend("Fedorov", "ul.Antonova", "18003", "28.01.2004"));
            TG.Add(new Friend("Ryblov", "ul.Veselaya", "10011", "15.03.1980"));
            TG.Add(new Ogranization(new string[] { "Ivanov", "Pupov"}, "ul.Universitetskaya", "10041", "12-32-84", "UMA"));
            TG.Add(new Ogranization(new string[] { "Raykin", "Pupa", "Ivanov"}, "ul.Tarhova", "10101", "54-35-64", "Malyata"));*/

            Print(TG);
            TG.Sort();
            Print(TG);
            string[] sur = { "Pupa" };
            var findBySurname =
                from pers in TG
                where pers.InGuide(sur)[0] == true
                select pers;
            
            List<TelephoneGuide> find_sur = new List<TelephoneGuide>();
            foreach (var s in findBySurname)
            {
                find_sur.Add(s);
            }
            Print(find_sur);

            using (FileStream f = new FileStream("C:\\siacode\\SIACOD\\PR18_8\\PR18_8\\input.dat",
                    FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(f, TG);
                    }           
        }
    }
}

