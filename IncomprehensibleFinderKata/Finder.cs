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

            for (var i = 0; i < people.Count - 1; i++) {
                for (var j = i + 1; j < people.Count; j++) {
                    Couple couple;
                    if (people[i].BirthDate < people[j].BirthDate) {
                        couple = new Couple(people[i], people[j]);
                    }
                    else {
                        couple = new Couple(people[i], people[j]);
                    }
                    couple.DifferenceBetweenBirthdates = couple.SecondPerson.BirthDate - couple.FirstPerson.BirthDate;
                    couples.Add(couple);
                }
            }

            return couples;
        }
    }

    public class NoCouple : Couple {
        public NoCouple() : base(null, null) { }
    }
}