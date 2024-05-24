using System;
using System.Collections.Generic;
//using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;
using Telephone;

namespace SSU.ThreeLayer.DAL
{
    public interface IBaseTelephoneGuide
    {
        void AddPerson(TelephoneGuide persons);
        void DeletePerson(string name);
        IEnumerable<TelephoneGuide> GetAllPerson();
        Person GetPerson(string name);
        IEnumerable<TelephoneGuide> FindPeopleByNumber(string number);
    }
}