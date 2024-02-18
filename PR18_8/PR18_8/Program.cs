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
            Console.WriteLine("--------");
            foreach (var t in TG)
            {
                t.GetInfo();
            }
            Console.WriteLine("--------");
        }
    static void Main(string[] args)
    {
        List<TelephoneGuide> TG = new List<TelephoneGuide>();
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream f = new FileStream("C:\\Users\\chike\\source\\repos\\PR18_8\\PR18_8\\input.dat",
         FileMode.OpenOrCreate))
            {
                if (f.Length != 0)
                {
                    TG = (List<TelephoneGuide>)formatter.Deserialize(f);
                }
            }
            Print(TG);
                    ////
                    TG.Add(new Person("Ivanov", "pushkina dom kalatushkina", "99999"));
                    TG.Add(new Person("Ivanov2", "pushkina1 dom kalatushkina", "99994"));
                    TG.Add(new Person("Ivanov3", "pushkina2 dom kalatushkina", "99995"));
                    TG.Add(new Person("Ivanov", "pushkina3 dom kalatushkina", "99996"));
                    TG.Add(new Friend("Ivanov", "pushkina dom kalatushkina", "99999", "28.01.2004"));
                    TG.Add(new Friend("Ivanov2", "pushkina1 dom kalatushkina", "99994", "15.03.1980"));
                    TG.Add(new Ogranization("Ivanov", "pushkina2 dom kalatushkina", "99995", "12324", "345435"));
                    TG.Add(new Ogranization("Ivanov4", "pushkina3 dom kalatushkina", "99996", "54354", "435435345"));
                    ////
            Print(TG);
            //TG.Sort();
            //Print(TG);
            string[] sur = { "Ivanov" };
            var findBySurname =
                from pers in TG
                where pers.InGuide(sur)[0] == true
                select pers;
            List<TelephoneGuide> find_sur = new List<TelephoneGuide>();
            foreach(var s in findBySurname) {
                find_sur.Add(s);
            }
            Print(find_sur);
            using (FileStream f = new FileStream("C:\\Users\\chike\\source\\repos\\PR18_8\\PR18_8\\input.dat",
                    FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(f, TG);
                    }           
        }
    }
}

