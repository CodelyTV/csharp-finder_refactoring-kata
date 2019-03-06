using System;
using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata {
    public class Couple {
        public Person FirstPerson { get; }
        public Person SecondPerson { get; }
        public int DaysBetweenBirthdates { get; }

        protected Couple() { }
        public Couple(Person firstPerson, Person secondPerson) {
            var people = new List<Person> {firstPerson, secondPerson}.OrderBy(p => p.BirthDate);
            FirstPerson = people.First();
            SecondPerson = people.Last();
            DaysBetweenBirthdates = (SecondPerson.BirthDate - FirstPerson.BirthDate).Days;
        }
    }
}