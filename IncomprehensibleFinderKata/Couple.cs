using System;

namespace IncomprehensibleFinderKata {
    public class Couple {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan D { get; private set; }

        public Couple() { }
        public Couple(Person firstPerson, Person secondPerson) {
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            D = SecondPerson.BirthDate - FirstPerson.BirthDate;
        }
    }
}