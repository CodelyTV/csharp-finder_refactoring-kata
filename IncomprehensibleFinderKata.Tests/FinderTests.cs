using System;
using System.Collections.Generic;
using Xunit;

namespace IncomprehensibleFinderKata.Tests {
    public class FinderTests {
        private readonly Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        public readonly Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        private readonly Person sarah = new Person() {Name = "Sarah", BirthDate = new DateTime(1982, 1, 1)};
        private readonly Person mike = new Person() {Name = "Mike", BirthDate = new DateTime(1979, 1, 1)};

        [Fact]
        public void Returns_No_Couple_When_Given_Empty_List() {
            var people = new List<Person>();
            var finder = new Finder(people);

            var noCouple = finder.Find(FilterType.Closest);

            Assert.Null(noCouple.FirstPerson);
            Assert.Null(noCouple.SecondPerson);
        }

        [Fact]
        public void Returns_No_Couple_When_Given_One_Person() {
            var people = new List<Person>() {sue};
            var finder = new Finder(people);

            var noCouple = finder.Find(FilterType.Closest);

            Assert.Null(noCouple.FirstPerson);
            Assert.Null(noCouple.SecondPerson);
        }

        [Fact]
        public void Returns_Closest_Couple_For_Two_People() {
            var people = new List<Person>() {sue, greg};
            var finder = new Finder(people);

            var closestCouple = finder.Find(FilterType.Closest);

            Assert.Same(sue, closestCouple.FirstPerson);
            Assert.Same(greg, closestCouple.SecondPerson);
        }

        [Fact]
        public void Returns_Furthest_Couple_For_Two_People() {
            var people = new List<Person>() {greg, mike};
            var finder = new Finder(people);

            var furthestCouple = finder.Find(FilterType.Furthest);

            Assert.Same(greg, furthestCouple.FirstPerson);
            Assert.Same(mike, furthestCouple.SecondPerson);
        }

        [Fact]
        public void Returns_Furthest_Couple_For_Four_People() {
            var people = new List<Person>() {greg, mike, sarah, sue};
            var finder = new Finder(people);

            var furthestCouple = finder.Find(FilterType.Furthest);

            Assert.Same(sue, furthestCouple.FirstPerson);
            Assert.Same(sarah, furthestCouple.SecondPerson);
        }

        [Fact]
        public void Returns_Closest_Couple_For_Four_People() {
            var people = new List<Person>() {greg, mike, sarah, sue};
            var finder = new Finder(people);

            var closestCouple = finder.Find(FilterType.Closest);

            Assert.Same(sue, closestCouple.FirstPerson);
            Assert.Same(greg, closestCouple.SecondPerson);
        }
    }
}