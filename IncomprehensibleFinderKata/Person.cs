// <copyright file="Person.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System;

    public class Person
    {
        private readonly string name;
        private DateTime birthDate;

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.BirthDate = birthDate;
        }

        public DateTime BirthDate
        {
            get => this.birthDate;
            set
            {
                if (value > DateTime.Now.Date)
                {
                    throw new ArgumentNullException(nameof(this.birthDate));
                }

                this.birthDate = value;
            }
        }
    }
}