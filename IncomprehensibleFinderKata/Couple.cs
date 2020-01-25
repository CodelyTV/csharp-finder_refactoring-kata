// <copyright file="Couple.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System;

    public class Couple
    {
        public Couple()
        {
        }

        public Couple(Person? youngest, Person? oldest)
        {
            this.Youngest = youngest ?? throw new ArgumentNullException(nameof(youngest));
            this.Oldest = oldest ?? throw new ArgumentNullException(nameof(oldest));
        }

        public Person? Youngest { get; set; }

        public Person? Oldest { get; set; }

        public TimeSpan Distance { get; set; }
    }
}