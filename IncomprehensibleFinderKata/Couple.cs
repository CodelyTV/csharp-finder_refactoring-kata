using System;
using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata {
    public class Couple {
        public Person YoungerPerson { get; }
        public Person OlderPerson { get; }
        public int DaysBetweenBirthdates { get; }

        protected Couple() { }
        public Couple(Person firstPerson, Person secondPerson) {
            var people = new List<Person> {firstPerson, secondPerson}.OrderBy(p => p.BirthDate);
            YoungerPerson = people.First();
            OlderPerson = people.Last();
            DaysBetweenBirthdates = (OlderPerson.BirthDate - YoungerPerson.BirthDate).Days;
        }
    }
}