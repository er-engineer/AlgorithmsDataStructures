using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Set
{
    public class DisjointSet<T> : IEnumerable<T> where T : notnull
    {
        private Dictionary<T, DisjointSetNode<T>> Set =
            new Dictionary<T, DisjointSetNode<T>>();
        public int Count { get; private set; }

        public DisjointSet(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                MakeSet(item);
            }   
        }
        public void MakeSet(T value)
        {
            if(Set.ContainsKey(value)) 
                throw new Exception("This node is already part of the set.");
            
            Set.Add(value, new DisjointSetNode<T>(value));
            Count++;
        }

        public T Find(T value)
        {
            if(!Set.ContainsKey(value))
                throw new Exception("This node is not part of the set.");
            return FindNode(Set[value]).Value;
        }

        private DisjointSetNode<T> FindNode(DisjointSetNode<T> node)
        {
            if(node.Parent != node)
                node.Parent = FindNode(node.Parent);
            return node.Parent;
        }

        public void Union(T valueX, T valueY)
        {
            var rootX = Find(valueX);
            var rootY = Find(valueY);

            if(rootX.Equals(rootY))
                return;
            
            if(Set[rootX].Rank == Set[rootY].Rank)
            {
                Set[rootY].Parent = Set[rootX];
                Set[rootX].Rank++;
            }
            else
            {
                if (Set[rootX].Rank < Set[rootY].Rank)
                {
                    Set[rootX].Parent = Set[rootY];
                }
                else if(Set[rootX].Rank > Set[rootY].Rank)
                {
                    Set[rootY].Parent = Set[rootX];
                }
            } 
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Set.Values.Select(node => node.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
