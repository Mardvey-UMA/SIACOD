using System;
using System.Collections.Generic;
using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.DAL
{
    public interface IBasePerson
    {
        void AddPerson(Person persons);
        void DeletePerson(string name);
        IEnumerable<Person> GetAllPerson();
        Person GetPerson(string name);
        IEnumerable<Person> FindPeopleByAgeRange( int minAge, int maxAge);
    }
}