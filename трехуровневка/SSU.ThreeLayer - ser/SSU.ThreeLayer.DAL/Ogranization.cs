using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone;

namespace Telephone
{
    [Serializable]
    public class Ogranization : TelephoneGuide
    {
        protected string[] contact_face;
        protected string orgname;
        protected string faks;
        protected string addres;
        readonly string type_k = "Org";
        // конструктор
        public Ogranization(string[] contact_face, string addres, string number, string faks, string orgname)
        {
            this.number = number;
            this.contact_face = contact_face;
            this.addres = addres;
            this.faks = faks;
            this.orgname = orgname;
        }
        public override void GetInfo()
        {
            Console.Write("Контактные лица: ");
            foreach (var contact in contact_face)
            {
                Console.Write(contact);
                Console.Write(" ");
            }
            Console.Write($" Адрес: {addres}");
            Console.Write($" тел.номер: {number}");
            Console.Write($" факс: {faks}");
            Console.Write($" название: {orgname}\n");
        }
        public override void Set(params string[] args)
        {
            if (args.Length == 5)
            {

                //this.surname = args[0];
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
            bool[] res = { false };
            foreach (var contact in contact_face)
            {
                if (contact == args[0])
                {
                    res[0] = true;
                    break;
                }
            }
            return res;
        }
    }
}
