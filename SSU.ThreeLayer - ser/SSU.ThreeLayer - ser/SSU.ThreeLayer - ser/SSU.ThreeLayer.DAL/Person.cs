using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pr18_gl1_6
{
    [Serializable]
    public abstract class Person : IComparable<Person>
    {
        public DateTime dateOfBirth;
        public string lastName { get; set; }
        public string faculty;

        public int CompareTo(Person other)
        {
            return this.dateOfBirth.CompareTo(other.dateOfBirth);
        }
        public Person()
        {
        }
        public Person(string lastName, DateTime dateOfBirth, string faculty)
        {
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.faculty = faculty;
        }

        abstract public void ShowInfo();
        abstract public override string ToString();

        public int CalculateAge()
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - dateOfBirth.Year;
            if (currentDate < dateOfBirth.AddYears(age)) age--;
            return age;
        }
        public static List<Person> FindPeopleByAgeRange(List<Person> people, int minAge, int maxAge)
        {
            return people.FindAll(person => person.CalculateAge() >= minAge && person.CalculateAge() <= maxAge);
        }
    }
}
