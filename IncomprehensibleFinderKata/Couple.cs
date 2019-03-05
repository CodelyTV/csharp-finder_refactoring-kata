using System;

namespace IncomprehensibleFinderKata {
    public class Couple {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan DifferenceBetweenBirthdates { get; }

        public Couple() { }
        public Couple(Person firstPerson, Person secondPerson) {
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            DifferenceBetweenBirthdates = SecondPerson.BirthDate - FirstPerson.BirthDate;
        }
    }
}