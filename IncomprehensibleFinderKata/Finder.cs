using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata {
    public class Finder {
        private readonly List<Person> people;

        public Finder(List<Person> people) {
            this.people = people;
        }

        public Couple Find(Filter filter) {
            if (people.Count < 2) return new Couple();
            var couples = GetPossibleCouples();

            switch (filter) {
                case Filter.Closest:
                    return couples.OrderBy(c => c.DifferenceBetweenBirthdates).First();

                case Filter.Furthest:
                    return couples.OrderByDescending(c => c.DifferenceBetweenBirthdates).First();
            }
            return new Couple();
        }

        private List<Couple> GetPossibleCouples() {
            var couples = new List<Couple>();

            for (var i = 0; i < people.Count - 1; i++) {
                for (var j = i + 1; j < people.Count; j++) {
                    var couple = new Couple();
                    if (people[i].BirthDate < people[j].BirthDate) {
                        couple.FirstPerson = people[i];
                        couple.SecondPerson = people[j];
                    }
                    else {
                        couple.FirstPerson = people[j];
                        couple.SecondPerson = people[i];
                    }

                    couple.DifferenceBetweenBirthdates = couple.SecondPerson.BirthDate - couple.FirstPerson.BirthDate;
                    couples.Add(couple);
                }
            }

            return couples;
        }
    }
}