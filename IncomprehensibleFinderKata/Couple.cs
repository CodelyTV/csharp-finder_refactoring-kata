// <copyright file="Couple.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System;

    public class Couple
    {
        public Person Youngest { get; }

        public Person Oldest { get; }

        public TimeSpan Distance { get; }

        public Couple(Person youngest, Person oldest)
        {
            this.Youngest = youngest ?? throw new ArgumentNullException(nameof(youngest));
            this.Oldest = oldest ?? throw new ArgumentNullException(nameof(oldest));
            this.Distance = this.CalculeDistance(oldest, youngest);
        }

        private TimeSpan CalculeDistance(Person oldest, Person youngest)
        {
            var distance = oldest.BirthDate - youngest.BirthDate;

            if (this.IsValidDistance(distance))
            {
                throw new ArgumentNullException($"{nameof(youngest)} is greater than {nameof(oldest)}");
            }

            return distance;
        }

        private bool IsValidDistance(TimeSpan distance)
        {
            return distance < TimeSpan.Zero;
        }
    }
}