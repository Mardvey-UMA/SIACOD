using System;
using System.Collections.Generic;
using Pr18_gl1_6;
using SSU.ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public class Telephon_guide_logic : ITelephon_guide
    {
        private readonly IBaseTelephoneGuide TelephoneGuideList;

        public Telephon_guide_logic(IBaseTelephoneGuide _TelephoneGuideList)
        {
            TelephoneGuideList = _TelephoneGuideList;
        }

        public void AddPerson(Person person )
        {
            TelephoneGuideList.AddPerson(person);
        }

        public void DeletePerson(string name)
        {
            TelephoneGuideList.DeletePerson(name);
        }

        public IEnumerable<TelephoneGuide> GetAllPerson()
        {
            return TelephoneGuideList.GetAllPerson();
        }

        public TelephoneGuide GetPerson(string name)
        {
            return TelephoneGuideList.GetPerson(name);
        }
        
        public IEnumerable<TelephoneGuide> FindPeopleByNumber(string number)
        {
            return TelephoneGuideList.FindPeopleByNumber(string number);
        }
    }
}