using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone;

namespace Telephone
{
    [Serializable]
    public class Ogranization : Person
    {
        protected string orgname;
        protected string faks;
        readonly string type_k = "Org";
        // конструктор
        public Ogranization(string surname, string addres, string number, string faks, string orgname)
        : base(surname, addres, number)
        {
            this.faks = faks;
            this.orgname = orgname;
        }
        public override void GetInfo()
        {
            Console.Write($"Контакт лицо: {surname}");
            Console.Write($" Адрес: {addres}");
            Console.Write($" тел.номер: {number}");
            Console.Write($" факс: {faks}");
            Console.Write($" название: {orgname}\n");
        }
        public override void Set(params string[] args)
        {
            if (args.Length == 5)
            {
                this.surname = args[0];
                this.addres = args[1];
                this.number = args[2];
                this.faks = args[3];
                this.orgname = args[4];
            }
            else
            {

                throw new Exception($"Ошибка в кол-ве аргументов, принято: {args.Length}, необходимо: 5");
            }
        }
        public override bool[] InGuide(params string[] args)
        {
            string[] temp = { this.surname, this.addres, this.number, this.faks, this.orgname };
            bool[] res = { false, false, false, false, false };
            for (int i = 0; i < args.Length; i++)
            {
                res[i] = (temp[i] == args[i]);
            }
            return res;
        }

    }
}
