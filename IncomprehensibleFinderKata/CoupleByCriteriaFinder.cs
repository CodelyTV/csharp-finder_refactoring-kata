// <copyright file="CoupleByCriteriaFinder.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System.Collections.Generic;

    public class CoupleByCriteriaFinder
    {
        private readonly List<Person> people;

        public CoupleByCriteriaFinder(List<Person> people)
        {
            this.people = people;
        }

        public Couple Find(Criteria criteria)
        {
            var coupleCombinations = new List<Couple>();

            for (var i = 0; i < this.people.Count - 1; i++)
            {
                for (var j = i + 1; j < this.people.Count; j++)
                {
                    var couple = new Couple();
                    if (this.people[i].BirthDate < this.people[j].BirthDate)
                    {
                        couple.Youngest = this.people[i];
                        couple.Oldest = this.people[j];
                    }
                    else
                    {
                        couple.Youngest = this.people[j];
                        couple.Oldest = this.people[i];
                    }

                    couple.Distance = couple.Oldest.BirthDate - couple.Youngest.BirthDate;
                    coupleCombinations.Add(couple);
                }
            }

            if (coupleCombinations.Count < 1)
            {
                return new Couple();
            }

            Couple answer = coupleCombinations[0];
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
    }
}