using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telephone;
namespace Telephone
{
    [Serializable]
    public class Person : TelephoneGuide
    {
        protected string surname;
        protected string addres;
        readonly string type_k = "Person";
        // конструктор
        public Person(string surname, string addres, string number)
        {
            this.surname = surname;
            this.addres = addres;
            this.number = number;
        }

        public override void Set(params string[] args)
        {
            if (args.Length == 3)
            {
                this.surname = args[0];
                this.addres = args[1];
                this.number = args[2];
            }
            else
            {
                throw new Exception($"Ошибка в кол-ве аргументов, принято: {args.Length}, необходимо: 3");
            }
        }
        public override void GetInfo()
        {
            Console.Write($"Фамилия: {surname}");
            Console.Write($" Адрес: {addres}");
            Console.Write($" тел.номер: {number}\n");
        }

        public override bool[] InGuide(params string[] args)
        {
            string[] temp = { this.surname, this.addres, this.number };
            bool[] res = { false, false, false };
            for (int i = 0; i < args.Length; i++)
            {
                res[i] = (temp[i] == args[i]);
            }
            return res;
        }
    }
}
