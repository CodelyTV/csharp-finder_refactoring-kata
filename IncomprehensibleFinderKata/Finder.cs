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

        public FindResult Find(Filter filter)
        {
            var tr = new List<FindResult>();

            for(var i = 0; i < persons.Count - 1; i++)
            {
                for(var j = i + 1; j < persons.Count; j++)
                {
                    var result = new FindResult();
                    if(persons[i].BirthDate < persons[j].BirthDate)
                    {
                        result.P1 = persons[i];
                        result.P2 = persons[j];
                    }
                    else
                    {
                        result.P1 = persons[j];
                        result.P2 = persons[i];
                    }
                    result.D = result.P2.BirthDate - result.P1.BirthDate;
                    tr.Add(result);
                }
            }

            if(tr.Count < 1)
            {
                return new FindResult();
            }

            FindResult answer = tr[0];
            foreach(var result in tr)
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