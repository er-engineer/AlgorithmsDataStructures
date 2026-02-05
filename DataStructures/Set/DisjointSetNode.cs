using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Set
{
    public class DisjointSetNode<T>
    {
        public T Value { get; set; }
        public int Rank { get; set; }
        public DisjointSetNode<T> Parent { get; set; }
        public DisjointSetNode(T value)
        {
            Value = value;
            Rank = 0;
            Parent = this;
        }
        public DisjointSetNode(T value, int rank)
        {
            Value = value;
            Rank = rank;
            Parent = this;
        }
        public override string ToString()
        {
            return $"{Value}";
        }
         
    }
}
