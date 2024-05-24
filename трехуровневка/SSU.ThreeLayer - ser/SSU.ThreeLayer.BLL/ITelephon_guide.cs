using System;
using System.Collections.Generic;
using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public interface ITelephon_guide
    {
        void AddPerson(TelephoneGuide product);
        void DeletePerson(string name);
        IEnumerable<TelephoneGuide> GetAllPerson();
        Person GetPerson(string name);
        IEnumerable<TelephoneGuide> FindPeopleByNumber(string number);
    }
}