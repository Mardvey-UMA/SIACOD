using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pr18_gl1_6
{
    [Serializable]
    public class Teacher : Person
    {
        protected string position;
        protected int experience;

        public Teacher(string lastName, DateTime dateOfBirth, string faculty, string position, int experience) : base(lastName, dateOfBirth, faculty)
        {
            this.position = position;
            this.experience = experience;
        }
        public Teacher() { }
        public override void ShowInfo()
        {
            Console.WriteLine($"Teacher: {lastName}, born on {dateOfBirth}, faculty: {faculty}, position: {position}, experience: {experience} years, age: {CalculateAge()}");
        }
        public override string ToString()
        {
            return $"Teacher: {lastName}, born on {dateOfBirth.ToString("dd.MM.yyyy")}, faculty: {faculty}, position: {position}, experience: {experience} years, age: {CalculateAge()}";
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