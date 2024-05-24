using SSU.ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SSU.ThreeLayer.BLL
{
    public class ClientLogic : IClientLogic
    {
        private IBaseClients baseClients;

        public ClientLogic(IBaseClients baseClients)
        {
            this.baseClients = baseClients;
        }

        public void AddClient(string name)
        { 
            baseClients.AddClient(new Client(name));

        }

        //добавление информации о покупке по номеру клиента
        public void AddBuying(int index, DateTime data, double sum)
        {
            baseClients.AddBuying(index, data, sum);
        }
        //добавление информации о покупке по фамилии клиента
        public void AddBuying(string name, DateTime data, double sum)
        {
            baseClients.AddBuying(name, data, sum);
        }
        //удаляем клиента по номеру
        public void DeleteClient(int index)
        {
            baseClients.DeleteClient(index);
        }
        //удаляем клиента по фамилии
        public void DeleteClient(string name)
        {
            baseClients.DeleteClient(name);
        }

        public Client GetClient(int index)
        {
            return baseClients.GetClient(index);
        }

        public IEnumerable GetAllClients()
        {
            return baseClients.GetAllClients();
        }
    }
}
