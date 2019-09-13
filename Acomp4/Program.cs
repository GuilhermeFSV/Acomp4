using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using TreeCollections;
using Xunit;

namespace Acomp4
{
    public class Program
    {
        public class Tests
        {
            // ReadonlyEntityTreeNode<int, int>
            public static List<int> root = new List<int>();

            [Params(100, 1000, 10000)]
            public int N { get; set; }

            public static int rootItem, addItem, removeItem, firstItem;

            [GlobalSetup]
            public void Setup()
            {
                int[] array = new RandomArray(N).Array;
                rootItem = array[0];
                addItem = new Random().Next(0, N-1);
                removeItem = array[N/2];
                firstItem = array[addItem];
                root.Clear();
                foreach (int item in array)
                {
                    root.Add(item);
                }
            }

            [Benchmark]
            public void AddTest()
            {
                root.Add(addItem);
            }

            [Benchmark]
            public void RemoveTest()
            {
                root.Remove(removeItem);
            }

            [Benchmark]
            public void FirstTest()
            {
                root.FirstOrDefault(i => i == firstItem);
            }

        }

        [Fact]
        public static void Test()
        {
            int[] array = new RandomArray(10).Array;
            int addItem = new Random().Next(0, 9);
            int removeItem = array[5];
            List<int> root = new List<int>();
            foreach (int item in array)
            {
                root.Add(item);
            }
            root.Add(addItem);
            Assert.Contains(addItem, root);
            root.RemoveAll(i => i == removeItem);
            Assert.DoesNotContain(removeItem, root);
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Tests>();
            Console.Read();
        }
    }
}
