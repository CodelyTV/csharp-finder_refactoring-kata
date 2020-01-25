// <copyright file="Person.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System;

    public class Person
    {
        private readonly string name;

        public DateTime BirthDate { get; }

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.BirthDate = birthDate;
        }

        public bool IsYoungerThan(Person person)
        {
            return this.BirthDate < person.BirthDate;
        }
    }
}