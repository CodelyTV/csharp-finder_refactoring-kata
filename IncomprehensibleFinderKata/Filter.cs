using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata {
    public class Filter {
        private readonly FilterType filterType;

        public Filter(FilterType filterType) {
            this.filterType = filterType;
        }

        public Couple ApplyOn(List<Couple> couples) {
            switch (filterType) {
                case FilterType.Closest:
                    return couples.OrderBy(c => c.DaysBetweenBirthdates).First();
                case FilterType.Furthest:
                    return couples.OrderByDescending(c => c.DaysBetweenBirthdates).First();
                default:
                    return new NoCouple();
            }
        }
    }
}