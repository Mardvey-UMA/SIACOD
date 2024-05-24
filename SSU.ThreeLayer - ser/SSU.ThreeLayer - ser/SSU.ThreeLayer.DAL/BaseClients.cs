using SSU.ThreeLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SSU.ThreeLayer.DAL
{
    public class BaseClients : IBaseClients
    {
        int index; //номер клиента, генерируется автоматически
        Dictionary<int, Client> clients; //список клиентов

        public BaseClients() //конструктор класса
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) //файл пуст, создаю новую базу
            {
                clients = new Dictionary<int, Client>();
                index = 0;
            }
            else // иначе выполняю дисериализацию
            {
                clients = (Dictionary<int, Client>)formatter.Deserialize(f);
                ICollection key = clients.Keys; // ищу последний ключ
                foreach (int item in key)
                {
                    index = item;
                }
            }
            f.Close();

        }
        ~BaseClients()
        {
            SaveBaseClients();
        }
        public void AddClient(Client client) //добавление нового клиента в хеш-таблицу:
        { //ключ – index, значение – экземпляр класса Client
            index++;
            client.id = index;
            clients.Add(index, client);
        }
        //добавление информации о покупке по номеру клиента
        public void AddBuying(int index, DateTime data, double sum)
        {
            Client item = clients[index];
            item.AddBuying(data, sum);
        }
        //добавление информации о покупке по фамилии клиента
        public void AddBuying(string name, DateTime data, double sum)
        {
            ICollection key = clients.Keys; //прочитали все ключи
            foreach (int index in key)
            {
                //использовуем ключ для получения значения хеш-таблицы
                Client item = clients[index];
                //если фамилия соответсвует фамиили клиента, то мы нашли нужного клиента
                if (string.Compare(name, item.name) == 0)
                {
                    AddBuying(index, data, sum); //и добавляет новую покупку по текущему ключу
                    break;
                }
            }
        }
        //удаляем клиента по номеру
        public void DeleteClient(int index)
        {
            clients.Remove(index);
        }
        //удаляем клиента по фамилии
        public void DeleteClient(string name)
        {
            ICollection key = clients.Keys;
            foreach (int index in key)
            {
                Client item = clients[index];
                if (string.Compare(name, item.name) == 0)
                {
                    DeleteClient(index);
                    break;
                }
            }
        }

        public Client GetClient(int index)
        {
            return clients[index];
        }

        public IEnumerable GetAllClients()
        {
            return clients.Values;
        }

        void SaveBaseClients()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, clients);
            }
        }
                
    }
}
