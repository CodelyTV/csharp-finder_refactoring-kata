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
            this.BirthDate = birthDate.Date;
            this.ValidateBirthDate();
        }

        public bool IsYoungerThan(Person person)
        {
            return this.BirthDate < person.BirthDate;
        }

        private void ValidateBirthDate()
        {
            if (this.IsBirthDateLessThanToday(this.BirthDate))
            {
                throw new ArgumentNullException("The birthDate cannot be greater than today's date");
            }
        }

        private bool IsBirthDateLessThanToday(DateTime birthDate)
        {
            return DateTime.Now < birthDate;
        }
    }
}