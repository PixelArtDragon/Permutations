using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations {
    public class Cycle<TElement> : IEquatable<Cycle<TElement>> where TElement : IEquatable<TElement> {
        //List<TElement> elements = new List<TElement>();

        Dictionary<TElement, TElement> successors = new Dictionary<TElement, TElement>();
        
        //public TElement GetElement(int index) {
        //    return elements[index];
        //}

        //public TElement Successor(TElement element) {
        //    int index = elements.IndexOf(element);
        //    if (index == -1) {
        //        return element;
        //    } else {
        //        return elements[(index + 1) % elements.Count];
        //    }
        //}

        public TElement Successor(TElement element) {
            if (successors.TryGetValue(element, out TElement value)) {
                return value;
            } else {
                return element;
            }
        }

        //public int Length {
        //    get {
        //        return elements.Count;
        //    }
        //}

        public int Length {
            get {
                return successors.Count;
            }
        }

        //public Cycle(List<Transposition<TElement>> transpositions) {
        //    if (transpositions.Count == 0) {
        //        return;
        //    }
        //    elements.Add(transpositions[0].first);
        //    elements.Add(transpositions[0].second);
        //    //First add any transpositions that are after the first transposition in the cycle
        //    int index = transpositions.FindIndex(transposition => transpositions[0].second.Equals(transposition.first));
        //    while (index != -1) { //Stop if a complete cycle has been created
        //        elements.Add(transpositions[index].second);
        //        index = transpositions.FindIndex(transposition => transpositions[index].second.Equals(transposition.first));
        //    }
        //    //Now that the forward transpositions have been added in order, push the backwards ones onto a stack and append
        //    List<TElement> backwardsTranspositions = new List<TElement>();
        //    index = transpositions.FindIndex(transposition => transpositions[0].first.Equals(transposition.second));
        //    while (index != -1) {
        //        backwardsTranspositions.Add(transpositions[index].first);
        //        if (backwardsTranspositions.Last().Equals(elements.Last())) { //The last element backwards is the last element fowards means a closed loop
        //            break;
        //        }
        //        index = transpositions.FindIndex(transposition => transpositions[index].first.Equals(transposition.second));
        //    }
        //    backwardsTranspositions.Reverse();
        //    elements.AddRange(backwardsTranspositions);
        //}

        public Cycle(List<Transposition<TElement>> transpositions) {
            foreach (var transposition in transpositions) {
                successors[transposition.first] = transposition.second;
            }
            successors[successors.Values.Except(successors.Keys).First()] = successors.Keys.Except(successors.Values).First();
        }


        //public List<Transposition<TElement>> ToTranspositions() {
        //    List<Transposition<TElement>> transpositions = new List<Transposition<TElement>>();
        //    for (int i = 0; i < elements.Count - 1; i++) {
        //        transpositions.Add(new Transposition<TElement>(elements[i], elements[i + 1]));
        //    }
        //    if (transpositions.Count > 2) { //

        //    }
        //    return transpositions;
        //}

        public List<Transposition<TElement>> ToTranspositions() {
            List<Transposition<TElement>> transpositions = new List<Transposition<TElement>>();
            TElement beginning = successors.Keys.First();
            TElement next = beginning;
            do {
                transpositions.Add(new Transposition<TElement>(next, successors[next]));
                next = successors[next];
            } while (next.Equals(beginning) == false);
            return transpositions;
        }

        //public bool Equals(Cycle<TElement> other) {
        //    //Cycles of different length cannot be equal
        //    if(other.elements.Count != this.elements.Count) {
        //        return false;
        //    }
        //    //Match up the start of the cycle
        //    int otherStartIndex = other.elements.FindIndex(element => element.Equals(this.elements[0]));
        //    if (otherStartIndex == -1) {
        //        return false;
        //    }
        //    //Iterate over the elements of this and see if the corresponding element matches
        //    for (int i = 1; i < this.elements.Count; i++) {
        //        if (this.elements[i].Equals(other.elements[(otherStartIndex + i) % this.elements.Count]) == false) {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public bool Equals(Cycle<TElement> other) {
            if (this.successors.Count != other.successors.Count) {
                return false;
            }
            foreach(var key in this.successors.Keys) {
                if(this.successors[key].Equals(other.successors[key]) == false) {
                    return false;
                }
            }
            return true;
        }

        public bool Intersects(Cycle<TElement> other) {
            return this.successors.Keys.Intersect(other.successors.Keys).Any();
        }
    }
}
