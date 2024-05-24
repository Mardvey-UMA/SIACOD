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
    public class Student : Applicant
    {
        protected int course;
        public Student(string lastName, DateTime dateOfBirth, string faculty, int course) : base(lastName, dateOfBirth, faculty)
        {
            this.course = course;
        }
        public Student() { }
        public override void ShowInfo()
        {
            Console.WriteLine($"Student: {lastName}, born on {dateOfBirth}, faculty: {faculty}, course: {course}, age: {CalculateAge()}");
        }
        public override string ToString()
        {
            return $"Student: {lastName}, born on {dateOfBirth.ToString("dd.MM.yyyy")}, faculty: {faculty}, course: {course}, age: {CalculateAge()}";
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
