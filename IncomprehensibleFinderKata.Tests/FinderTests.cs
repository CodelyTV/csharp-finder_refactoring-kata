// <copyright file="FinderTests.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class FinderTests
    {
        private readonly Person sue = new Person("Sue", new DateTime(1950, 1, 1));
        private readonly Person greg = new Person("Greg", new DateTime(1952, 6, 1));
        private readonly Person sarah = new Person("Sarah", new DateTime(1982, 1, 1));
        private readonly Person mike = new Person("Mike", new DateTime(1979, 1, 1));

        [Fact]
        public void Returns_Empty_Couple_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new CoupleByCriteriaFinder(list);

            var couple = finder.Find(Criteria.Closest);

            Assert.Null(couple.Youngest);
            Assert.Null(couple.Oldest);
        }

        [Fact]
        public void Returns_Empty_Couple_When_Given_One_Person()
        {
            var list = new List<Person>() { this.sue };
            var finder = new CoupleByCriteriaFinder(list);

            var couple = finder.Find(Criteria.Closest);

            Assert.Null(couple.Youngest);
            Assert.Null(couple.Oldest);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { this.sue, this.greg };
            var finder = new CoupleByCriteriaFinder(list);

            var couple = finder.Find(Criteria.Closest);

            Assert.Same(this.sue, couple.Youngest);
            Assert.Same(this.greg, couple.Oldest);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { this.greg, this.mike };
            var finder = new CoupleByCriteriaFinder(list);

            var couple = finder.Find(Criteria.Farthest);

            Assert.Same(this.greg, couple.Youngest);
            Assert.Same(this.mike, couple.Oldest);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { this.greg, this.mike, this.sarah, this.sue };
            var finder = new CoupleByCriteriaFinder(list);

            var couple = finder.Find(Criteria.Farthest);

            Assert.Same(this.sue, couple.Youngest);
            Assert.Same(this.sarah, couple.Oldest);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { this.greg, this.mike, this.sarah, this.sue };
            var finder = new CoupleByCriteriaFinder(list);

            var couple = finder.Find(Criteria.Closest);

            Assert.Same(this.sue, couple.Youngest);
            Assert.Same(this.greg, couple.Oldest);
        }
    }
}