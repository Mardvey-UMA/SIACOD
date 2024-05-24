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
    [XmlInclude(typeof(Student))]

    public class Applicant : Person
    {
        public Applicant(string lastName, DateTime dateOfBirth, string faculty) : base(lastName, dateOfBirth, faculty)
        {
        }
        public Applicant() { }
        public override void ShowInfo()
        {
            Console.WriteLine($"Applicant: {lastName}, born on {dateOfBirth}, faculty: {faculty}, age: {CalculateAge()}");
        }
        public override string ToString()
        {
            return $"Applicant: {lastName}, born on {dateOfBirth.ToString("dd.MM.yyyy")}, faculty: {faculty}, age: {CalculateAge()}";
        }
        public new int CalculateAge()
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - dateOfBirth.Year;
            if (currentDate < dateOfBirth.AddYears(age)) age--;
            return age;
        }
        public static new List<Person> FindPeopleByAgeRange(List<Person> people, int minAge, int maxAge)
        {
            return people.FindAll(person => person.CalculateAge() >= minAge && person.CalculateAge() <= maxAge);
        }
    }
}
