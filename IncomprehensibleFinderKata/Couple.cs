using System;

namespace IncomprehensibleFinderKata
{
    public class Couple
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan DifferenceBetweenBirthdates { get; set; }
    }
}