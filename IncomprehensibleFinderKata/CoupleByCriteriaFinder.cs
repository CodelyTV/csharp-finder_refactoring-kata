// <copyright file="CoupleByCriteriaFinder.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System.Collections.Generic;
    using System.Linq;

    public class CoupleByCriteriaFinder
    {
        private readonly List<Person> people;

        public CoupleByCriteriaFinder(List<Person> people)
        {
            this.people = people;
        }

        public Couple Find(Criteria criteria)
        {
            var coupleCombinations = this.GenerateCombinationCouple(this.people);

            Couple answer = coupleCombinations.FirstOrDefault();
            foreach (var potencialResult in coupleCombinations)
            {
                switch (criteria)
                {
                    case Criteria.Closest:
                        if (potencialResult.Distance < answer.Distance)
                        {
                            answer = potencialResult;
                        }

                        break;

                    case Criteria.Farthest:
                        if (potencialResult.Distance > answer.Distance)
                        {
                            answer = potencialResult;
                        }

                        break;
                }
            }

            return answer;
        }

        private Couple GenerateCouple(Person person1, Person person2)
        {
            return person1.IsYoungerThan(person2) ? new Couple(person1, person2) : new Couple(person2, person1);
        }

        private IEnumerable<Couple> GenerateCombinationCouple(IEnumerable<Person> people)
        {
            int limit = people.Count();

            return people.SelectMany((person1, index) =>
            {
                return people.Skip(index + 1).Take(limit).Select(person2 =>
                {
                    var couple = this.GenerateCouple(person1, person2);
                    return couple;
                }).ToList();
            });
        }
    }
}