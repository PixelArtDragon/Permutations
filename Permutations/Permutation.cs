using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class Permutation<TSet, TElement> where TSet : HashSet<TElement> where TElement : IEquatable<TElement>
    {
        List<Transposition<TElement>> transpositions;

        public Permutation() {
            
        }


        public static Permutation<TSet, TElement> operator *(Permutation<TSet, TElement> lhs, Permutation<TSet, TElement> rhs) {
            throw new NotImplementedException();
        }
    }
}
