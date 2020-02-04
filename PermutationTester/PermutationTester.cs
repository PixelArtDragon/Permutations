using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Permutations;

namespace PermutationTester {
    [TestClass]
    public class PermutationTester {
        [TestMethod]
        public void DisjointPermutations() {
            Permutation<int> permutation1 = new Permutation<int>(new System.Collections.Generic.List<Transposition<int>>() {
                new Transposition<int>(1, 2),
                new Transposition<int>(2, 3)
            });
            Permutation<int> permutation2 = new Permutation<int>(new System.Collections.Generic.List<Transposition<int>>() {
                new Transposition<int>(4, 5),
                new Transposition<int>(5, 6)
            });

            var permutation3 = permutation1 * permutation2;
            Assert.AreEqual(5, permutation3.Successor(4));
            Assert.AreEqual(6, permutation3.Successor(5));
            Assert.AreEqual(4, permutation3.Successor(6));
            Assert.AreEqual(2, permutation3.Successor(1));
            Assert.AreEqual(3, permutation3.Successor(2));
            Assert.AreEqual(1, permutation3.Successor(3));
        }

        [TestMethod]
        public void NonDisjointPermutations() {
            Permutation<int> permutation1 = new Permutation<int>(new System.Collections.Generic.List<Transposition<int>>() {
                new Transposition<int>(1, 2),
                new Transposition<int>(2, 4)
            });
            Permutation<int> permutation2 = new Permutation<int>(new System.Collections.Generic.List<Transposition<int>>() {
                new Transposition<int>(4, 5),
                new Transposition<int>(5, 6)
            });

            var permutation3 = permutation1 * permutation2;
            Assert.AreEqual(1, permutation3.Successor(6));
        }
    }
}
