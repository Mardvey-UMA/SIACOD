//using Pr18_gl1_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone;

namespace Telephone
{
    [Serializable]
    public class Friend : Person
    {
        protected string birthday;
        readonly string type_k = "Friend";
        // конструктор
        public Friend(string surname, string addres, string number, string birthday)
        : base(surname, addres, number)
        {
            this.birthday = birthday;
        }
        public override void Set(params string[] args)
        {
            if (args.Length == 4)
            {
                this.surname = args[0];
                this.addres = args[1];
                this.number = args[2];
                this.birthday = args[3];
            }
            else
            {
                throw new Exception($"Ошибка в кол-ве аргументов, принято: {args.Length}, необходимо: 4");
            }
        }
        public override void GetInfo()
        {
            Console.Write($"Фамилия: {surname}");
            Console.Write($" Адрес: {addres}");
            Console.Write($" тел.номер: {number}");
            Console.Write($" дата рождения: {birthday}\n");
        }
        public override bool[] InGuide(params string[] args)
        {
            string[] temp = { this.surname, this.addres, this.number, this.birthday };
            bool[] res = { false, false, false, false };
            for (int i = 0; i < args.Length; i++)
            {
                res[i] = (temp[i] == args[i]);
            }
            return res;
        }
    }
}
