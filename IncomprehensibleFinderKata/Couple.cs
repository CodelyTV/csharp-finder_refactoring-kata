// <copyright file="Couple.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System;

    public class Couple
    {
        public Person? Youngest { get; set; }

        public Person? Oldest { get; set; }

        public TimeSpan Distance { get; set; }
    }
}