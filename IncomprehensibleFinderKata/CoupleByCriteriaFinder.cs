// <copyright file="CoupleByCriteriaFinder.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CoupleByCriteriaFinder
    {
        private readonly IEnumerable<Couple> couples;

        public CoupleByCriteriaFinder(IEnumerable<Person> people)
        {
            people = people ?? throw new ArgumentNullException(nameof(people));
            this.couples = this.GenerateCombinationCouple(people);
        }

        public Couple FindByClosest()
        {
            return this.couples.OrderBy(u => u.Distance).FirstOrDefault();
        }

        public Couple FindByFarthest()
        {
            return this.couples.OrderByDescending(u => u.Distance).FirstOrDefault();
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
                    return this.GenerateCouple(person1, person2);
                }).ToList();
            });
        }
    }
}