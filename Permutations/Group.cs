using System.Collections.Generic;

namespace Permutations {
    public abstract class Group<TElement> : HashSet<TElement> {
        public abstract TElement Add(TElement lhs, TElement rhs);
        public abstract TElement Inverse(TElement lhs, TElement rhs);
    }
}