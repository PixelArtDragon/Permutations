using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Permutations;

namespace PermutationTester {
    [TestClass]
    public class CycleTester {
        [TestMethod]
        public void Length() {
            List<Transposition<int>> transpositions = new List<Transposition<int>> {
                new Transposition<int>(0, 1),
                new Transposition<int>(1, 2),
                new Transposition<int>(2, 3)
            };
            Cycle<int> testCycle = new Cycle<int>(transpositions);

            Assert.AreEqual(4, testCycle.Length);
        }

        [TestMethod]
        public void ListOutOfOrder() {
            List<Transposition<int>> transpositions = new List<Transposition<int>> {
                new Transposition<int>(1, 2),
                new Transposition<int>(0, 1),
                new Transposition<int>(2, 3)
            };

            Cycle<int> testCycle = new Cycle<int>(transpositions);

            Assert.AreEqual(3, testCycle.Successor(2));
        }

        [TestMethod]
        public void CycleToTranspositions() {
            List<Transposition<int>> transpositions = new List<Transposition<int>> {
                new Transposition<int>(1, 2),
                new Transposition<int>(0, 1),
                new Transposition<int>(2, 3)
            };

            Cycle<int> testCycle = new Cycle<int>(transpositions);
            CollectionAssert.Contains(testCycle.ToTranspositions(), new Transposition<int>(2, 3));
        }

        [TestMethod]
        public void CyclesEqual() {
            List<Transposition<int>> transpositions1 = new List<Transposition<int>> {
                new Transposition<int>(1, 2),
                new Transposition<int>(0, 1),
                new Transposition<int>(2, 3)
            };
            Cycle<int> cycle1 = new Cycle<int>(transpositions1);
            List<Transposition<int>> transpositions2 = new List<Transposition<int>> {
                new Transposition<int>(0, 1),
                new Transposition<int>(1, 2),
                new Transposition<int>(2, 3)
            };
            Cycle<int> cycle2 = new Cycle<int>(transpositions2);

            Assert.IsTrue(cycle1.Equals(cycle2));
            Assert.IsTrue(cycle2.Equals(cycle1));
        }

        [TestMethod]
        public void CyclesNotEqual() {
            List<Transposition<int>> transpositions1 = new List<Transposition<int>> {
                new Transposition<int>(1, 2),
                new Transposition<int>(0, 1),
                new Transposition<int>(2, 3)
            };
            Cycle<int> cycle1 = new Cycle<int>(transpositions1);
            List<Transposition<int>> transpositions2 = new List<Transposition<int>> {
                new Transposition<int>(0, 1),
                new Transposition<int>(1, 2),
            };
            Cycle<int> cycle2 = new Cycle<int>(transpositions2);

            Assert.IsFalse(cycle1.Equals(cycle2));
            Assert.IsFalse(cycle2.Equals(cycle1));
        }

        [TestMethod]
        public void SucessorInCycle() {
            List<Transposition<int>> transpositions = new List<Transposition<int>> {
                new Transposition<int>(0, 1),
                new Transposition<int>(1, 2),
                new Transposition<int>(2, 3)
            };
            Cycle<int> testCycle = new Cycle<int>(transpositions);
            Assert.AreEqual(3, testCycle.Successor(2));
        }

        [TestMethod]
        public void SucessorNotInCycle() {
            List<Transposition<int>> transpositions = new List<Transposition<int>> {
                new Transposition<int>(0, 1),
                new Transposition<int>(1, 2),
                new Transposition<int>(2, 3)
            };
            Cycle<int> testCycle = new Cycle<int>(transpositions);
            Assert.AreEqual(4, testCycle.Successor(4));
        }
    }
}
