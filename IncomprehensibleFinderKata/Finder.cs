// <copyright file="Finder.cs" company="CodelyTV">
// Copyright (c) CodelyTV. All rights reserved.
// </copyright>

namespace IncomprehensibleFinderKata
{
    using System.Collections.Generic;

    public class Finder
    {
        private readonly List<Thing> _p;

        public Finder(List<Thing> p)
        {
            this._p = p;
        }

        public F Find(FT ft)
        {
            var tr = new List<F>();

            for(var i = 0; i < this._p.Count - 1; i++)
            {
                for(var j = i + 1; j < this._p.Count; j++)
                {
                    var r = new F();
                    if(this._p[i].BirthDate < this._p[j].BirthDate)
                    {
                        r.P1 = this._p[i];
                        r.P2 = this._p[j];
                    }
                    else
                    {
                        r.P1 = this._p[j];
                        r.P2 = this._p[i];
                    }

                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new F();
            }

            F answer = tr[0];
            foreach(var result in tr)
            {
                switch(ft)
                {
                    case FT.One:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }

                        break;

                    case FT.Two:
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