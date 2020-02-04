using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class Permutation<TElement> where TElement : IEquatable<TElement>
    {
        Dictionary<TElement, TElement> successors = new Dictionary<TElement, TElement>();

        public Permutation() {
            
        }

        public Permutation(List<Transposition<TElement>> transpositions) {
            foreach (var transposition in transpositions) {
                successors[transposition.first] = transposition.second;
            }
            successors[successors.Values.Except(successors.Keys).First()] = successors.Keys.Except(successors.Values).First();
        }

        public Permutation(Cycle<TElement> cycle) {

        }

        public Permutation(params Cycle<TElement>[] cycles) {
            
        }

        public TElement Successor(TElement element) {
            if (successors.TryGetValue(element, out TElement value)) {
                return value;
            } else {
                return element;
            }
        }

        public List<Cycle<TElement>> ToCycles() {
            throw new NotImplementedException();
        }

        public static Permutation<TElement> operator *(Permutation<TElement> lhs, Permutation<TElement> rhs) {
            Permutation<TElement> permutation = new Permutation<TElement>();
            foreach (var key in rhs.successors.Keys.Union(lhs.successors.Keys)) {
                permutation.successors[key] = lhs.Successor(rhs.Successor(key));
            }
            return permutation;
        }
    }
}
