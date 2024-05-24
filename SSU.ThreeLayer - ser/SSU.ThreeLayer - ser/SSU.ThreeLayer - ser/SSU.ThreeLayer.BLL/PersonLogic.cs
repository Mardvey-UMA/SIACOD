using System;
using System.Collections.Generic;
using Pr18_gl1_6;
using SSU.ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IBasePerson PersonList;

        public PersonLogic(IBasePerson _personList)
        {
           PersonList = _personList;
        }

        public void AddPerson(Person person )
        {
            PersonList.AddPerson(person);
        }

        public void DeletePerson(string name)
        {
            PersonList.DeletePerson(name);
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return PersonList.GetAllPerson();
        }

        public Person GetPerson(string name)
        {
            return PersonList.GetPerson(name);
        }

        public IEnumerable<Person> FindPeopleByAgeRange( int minAge, int maxAge)
        {
            return PersonList.FindPeopleByAgeRange( minAge, maxAge);
        }
    }
}