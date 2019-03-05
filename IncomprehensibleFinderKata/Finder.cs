using System.Collections.Generic;

namespace IncomprehensibleFinderKata
{
    public class Finder
    {
        private readonly List<Person> persons;

        public Finder(List<Person> persons)
        {
            this.persons = persons;
        }

        public Couple Find(Filter filter)
        {
            var couples = new List<Couple>();

            for(var i = 0; i < persons.Count - 1; i++)
            {
                for(var j = i + 1; j < persons.Count; j++)
                {
                    var couple = new Couple();
                    if(persons[i].BirthDate < persons[j].BirthDate)
                    {
                        couple.P1 = persons[i];
                        couple.P2 = persons[j];
                    }
                    else
                    {
                        couple.P1 = persons[j];
                        couple.P2 = persons[i];
                    }
                    couple.D = couple.P2.BirthDate - couple.P1.BirthDate;
                    couples.Add(couple);
                }
            }

            if(couples.Count < 1)
            {
                return new Couple();
            }

            Couple answer = couples[0];
            foreach(var result in couples)
            {
                switch(filter)
                {
                    case Filter.Closest:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case Filter.Furthest:
                        if(result.D > answer.D)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}