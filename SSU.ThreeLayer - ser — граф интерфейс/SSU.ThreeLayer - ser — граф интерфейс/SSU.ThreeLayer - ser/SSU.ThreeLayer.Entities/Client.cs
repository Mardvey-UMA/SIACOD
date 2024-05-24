using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SSU.ThreeLayer.Entities
{
    [Serializable]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Purchase> Purchases { get; set; } // Список покупок

        [Serializable]
        public struct Purchase // Информация о каждой покупке
        {
            public DateTime Date { get; set; } // Дата покупки
            public double Sum { get; set; } // Сумма покупки

            public Purchase(DateTime date, double sum) // Конструктор структуры
            {
                Date = date;
                Sum = sum;
            }

            public override string ToString()
            {
                return String.Format("{0} {1}\n", Date.ToShortDateString(), Sum);
            }
        }

        public Client(string name) // Конструктор класса
        {
            Name = name;
            Purchases = new List<Purchase>();
        }

        public void AddPurchase(DateTime date, double sum) // Добавление данных о покупке
        {
            Purchase item = new Purchase(date, sum);
            Purchases.Add(item);
        }

        public override string ToString()
        {
            string str = $"Имя: {Name}" + Environment.NewLine;
            str += "Сведения о покупках: " + Environment.NewLine;
            foreach (Purchase item in Purchases)
            {
                str += item;
            }
            return str + Environment.NewLine;
        }
    }
}
