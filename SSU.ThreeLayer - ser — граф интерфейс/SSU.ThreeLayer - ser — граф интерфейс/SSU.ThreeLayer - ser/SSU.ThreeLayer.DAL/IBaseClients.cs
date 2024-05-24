using System;
using System.Collections;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.DAL
{
    public interface IBaseClients
    {
        void AddBuying(string name, DateTime data, double sum);
        void AddBuying(int index, DateTime data, double sum);
        void AddClient(Client client);
        void DeleteClient(string name);
        void DeleteClient(int index);
        IEnumerable GetAllClients();
        Client GetClient(int index);
    }
}