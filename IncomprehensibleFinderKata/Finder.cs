using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata
{
    public class Finder
    {
        private readonly List<Person> people;

        public Finder(List<Person> people)
        {
            this.people = people;
        }

        public Pair Find(Criteria criteria)
        {
            if (people.Count < 2) return new Pair();

            var pairs = GetPotentialPairsFrom(people);

            return FindMatchedPairByCriteria(criteria, pairs);
        }

        private static Pair FindMatchedPairByCriteria(Criteria criteria, List<Pair> pairs) {
            switch (criteria) {
                case Criteria.Closests:
                    return pairs.OrderBy(pair => pair.BirthdateDifference).First();
                case Criteria.Furthest:
                    return pairs.OrderBy(pair => pair.BirthdateDifference).Last();
                default:
                    return new Pair();
            }
        }

        private List<Pair> GetPotentialPairsFrom(List<Person> people) {
            var tr = new List<Pair>();

            for (var i = 0; i < people.Count - 1; i++) {
                for (var j = i + 1; j < people.Count; j++) {
                    var r = new Pair();
                    if (people[i].BirthDate < people[j].BirthDate) {
                        r.PersonOne = people[i];
                        r.PersonTwo = people[j];
                    }
                    else {
                        r.PersonOne = people[j];
                        r.PersonTwo = people[i];
                    }

                    r.BirthdateDifference = r.PersonTwo.BirthDate - r.PersonOne.BirthDate;
                    tr.Add(r);
                }
            }

            return tr;
        }
    }
}