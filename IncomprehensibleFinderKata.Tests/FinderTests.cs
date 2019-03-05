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
        public void Returns_Empty_Results_When_Given_Empty_List() {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(Filter.Closest);

            Assert.Null(result.P1);
            Assert.Null(result.P2);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person() {
            var list = new List<Person>() {sue};
            var finder = new Finder(list);

            var result = finder.Find(Filter.Closest);

            Assert.Null(result.P1);
            Assert.Null(result.P2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People() {
            var list = new List<Person>() {sue, greg};
            var finder = new Finder(list);

            var result = finder.Find(Filter.Closest);

            Assert.Same(sue, result.P1);
            Assert.Same(greg, result.P2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People() {
            var list = new List<Person>() {greg, mike};
            var finder = new Finder(list);

            var result = finder.Find(Filter.Furthest);

            Assert.Same(greg, result.P1);
            Assert.Same(mike, result.P2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People() {
            var list = new List<Person>() {greg, mike, sarah, sue};
            var finder = new Finder(list);

            var result = finder.Find(Filter.Furthest);

            Assert.Same(sue, result.P1);
            Assert.Same(sarah, result.P2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People() {
            var list = new List<Person>() {greg, mike, sarah, sue};
            var finder = new Finder(list);

            var result = finder.Find(Filter.Closest);

            Assert.Same(sue, result.P1);
            Assert.Same(greg, result.P2);
        }
    }
}