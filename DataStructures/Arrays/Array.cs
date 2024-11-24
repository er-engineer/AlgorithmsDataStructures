using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        public int Count { get; private set; }
        private T[] InnerList;
        public int Capacity => InnerList.Length;

        public Array()
        {
            InnerList = new T[0];
            Count = 0;
        }
        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
            {
                Add(item);
            }
        }

        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach (var item in collection)
                Add(item);
        }

        public void Add(T item)
        {
            
            T[] newArray = new T[Count + 1];
            for(int i = 0; i < Count; i++)
            {
                newArray[i] = InnerList[i];
            }
            InnerList = newArray;
            InnerList[Count++] = item;
        }

        public bool RemoveLast()
        {
            if (Count == 0)
            {
                Console.WriteLine("There is no more item to be removed.");
                return false;
            }
            else
            {
                T[] newArray = new T[Count-1];
                for(int i = 0; i < Count-1; i++)
                {
                    newArray[i] = InnerList[i];
                }
                InnerList = newArray;
                Count--;
                return true;
            }
        }

        public bool RemoveAt(int index)
        {
            if(Count == 0)
            {
                return this.RemoveLast();                
            }
            else if(index >= Count || index < 0)
            {
                Console.WriteLine("Index is out of boundaries.");
                return false;
            }
            else
            {
                InnerList[index] = default;
                T[] newArray = new T[Count - 1];
                int j = 0;
                for(int i = 0; i< Count; i++)
                {
                
                    if (InnerList[i].Equals(default(T)) && i == index)
                    {
                        continue;
                    }
                    else
                    {
                        newArray [j] = InnerList[i];
                        j++;
                    }
                }
           
                InnerList = newArray;
                return true;
            }
        }

        public void Insert(int index, T item)
        {
            T[] newArray = new T[Count + 1];
            int j = 0;

            if (index >= Count + 1 || index < 0)
            {
                Console.WriteLine("Index is out of boundaries.");
            }
            else
            {
                for (int i = 0; i < Count + 1; i++)
                {
                    if (index == i)
                    {
                        newArray[i] = item;
                    }
                    else
                    {
                        newArray[i] = InnerList[j];
                        j++;
                    }
                }
                InnerList = newArray;
            }  
            
        }

        public T GetElementAt(int index)
        { 
            return InnerList[index];
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Select(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
