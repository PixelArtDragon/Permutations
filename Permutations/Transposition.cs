using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations {
    public struct Transposition<TElement> where TElement : IEquatable<TElement> {

        public Transposition(TElement first, TElement second) {
            this.first = first;
            this.second = second;
        }


        public TElement first;
        public TElement second;

        public List<TElement> ToList() {
            return new List<TElement>() {
                first,
                second
            };
        }

        public static Transposition<TElement> operator -(Transposition<TElement> transposition) {
            return new Transposition<TElement>(transposition.second, transposition.first);
        }
    }
}
