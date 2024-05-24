using System;
using System.Collections;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public interface IClientLogic
    {
        void AddBuying(string name, DateTime data, double sum);
        void AddBuying(int index, DateTime data, double sum);
        void AddClient(string name);
        void DeleteClient(string name);
        void DeleteClient(int index);
        IEnumerable GetAllClients();
        Client GetClient(int index);
    }
}