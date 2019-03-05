using System.Collections.Generic;

namespace IncomprehensibleFinderKata
{
    public class Finder
    {
        private readonly List<Person> _p;

        public Finder(List<Person> p)
        {
            _p = p;
        }

        public FindResult Find(Filter filter)
        {
            var tr = new List<FindResult>();

            for(var i = 0; i < _p.Count - 1; i++)
            {
                for(var j = i + 1; j < _p.Count; j++)
                {
                    var r = new FindResult();
                    if(_p[i].BirthDate < _p[j].BirthDate)
                    {
                        r.P1 = _p[i];
                        r.P2 = _p[j];
                    }
                    else
                    {
                        r.P1 = _p[j];
                        r.P2 = _p[i];
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
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