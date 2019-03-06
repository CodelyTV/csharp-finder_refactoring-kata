using System;
using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata {
    public class Finder {
        private readonly List<Person> people;

        public Finder(List<Person> people) {
            this.people = people;
        }

        public Couple Find(FilterType filterType) {
            if (people.Count < 2) return new NoCouple();
            var couples = GetPossibleCouples();

            return new Filter(filterType).ApplyOn(couples);
        }

        private List<Couple> GetPossibleCouples() {
            var couples = new List<Couple>();
            var takenPeople = new List<Person>();
            foreach (var aPerson in people) {
                takenPeople.Add(aPerson);
                foreach (var otherPerson in people.Except(takenPeople)) {
                    couples.Add(new Couple(aPerson, otherPerson));
                }
            }
            return couples;
        }
    }
}