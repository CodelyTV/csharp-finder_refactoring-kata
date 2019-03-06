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
            var couples = GetAllCouples();

            return new Filter(filterType).ApplyOn(couples);
        }

        private List<Couple> GetAllCouples() {
            var takenPeople = new List<Person>();
            return people
                .Select(aPerson => {
                    takenPeople.Add(aPerson);
                    return people
                        .Except(takenPeople)
                        .Select(otherPerson => new Couple(aPerson, otherPerson));
                })
                .SelectMany(couple => couple)
                .ToList();
        }
    }
}