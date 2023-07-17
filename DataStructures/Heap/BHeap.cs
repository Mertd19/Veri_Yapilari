using DataStructures.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class BHeap<T> : IEnumerable<T> where T : IComparable
    {
        public T[] Array { get; private set; }
        private int position;
        public int Count { get; private set; }

        private readonly IComparer<T> comparer;
        private readonly bool isMax;

        public BHeap()
        {
            Count = 0;
            Array = new T[128];
            position = 0;
        }
        public BHeap(int size)
        {
            Count = 0;
            Array = new T[size];
            position = 0;
        }
        public BHeap(IEnumerable<T> colleciton)
        {
            Count = 0;
            Array = new T[colleciton.ToArray().Length];
            position = 0;
            foreach (var item in colleciton)
            {
                Add(item);
            }
        }
        public BHeap(SortDirection sortDirection = SortDirection.Asceding) : this(sortDirection,null,null)
        {
            
        }
        public BHeap(SortDirection sortDirection , IEnumerable<T> initial) : this(sortDirection,initial,null)
        {
            
        }
        public BHeap(SortDirection sortDirection , IComparer<T> comparer) : this(sortDirection,null, comparer)
        {
            
        }
        public BHeap(SortDirection sortDirection, IEnumerable<T> initial,IComparer<T> comparer)
        {
            position = 0;
            Count = 0;
            this.isMax = sortDirection == SortDirection.Descending;
            if(comparer != null)
            {
                this.comparer = new CustomComparer<T>(sortDirection,comparer);
            }
            else
            {
                this.comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
            }
            if(initial != null)
            {
                var items = initial as T[] ?? initial.ToArray();
                Array = new T[items.Count()];
                foreach(var item in items)
                {
                    Add(item);
                }
            }
            else
            {
                Array = new T[128];
            }
        }

        private int GetLeftChildIndex(int i) => i * 2 + 1;
        private int GetRightChildIndex(int i) => i * 2 + 2;
        private int GetParentIndex(int i) => (i - 1) / 2;
        private bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        private bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        private bool IsRoot(int i) => i == 0;
        private T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        private T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        private T GetParent(int i) => Array[GetParentIndex(i)];
        public bool isEmpty() => position == 0;
        public T Peek()
        {
            if (isEmpty())
            {
                throw new Exception("Empty Heap!");
            }
            return Array[0];

        }

        public void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public void Add(T value)
        {
            if (position == Array.Length) //Dizi doluysa
            {
                throw new IndexOutOfRangeException("Overflow!");
            }
            Array[position] = value;
            position++;
            Count++;
            HeapifyUp();
        }
        public T DeleteMinMax()
        {
            if (position == 0)
            {
                throw new IndexOutOfRangeException("Underflow!");
            }
            var temp = Array[0];
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smalllerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && comparer.Compare(GetRightChild(index), GetLeftChild(index)) < 0)
                {
                    smalllerIndex = GetRightChildIndex(index);
                }
                if (comparer.Compare(Array[smalllerIndex], Array[index])>=0)
                {
                    break;
                }
                Swap(smalllerIndex, index);
                index = smalllerIndex;
            }
        }
        protected void HeapifyUp()
        {

            var index = position - 1;
            while (!IsRoot(index) && comparer.Compare(Array[index], GetParent(index)) < 0)
            {
                var paretIndex = GetParentIndex(index);
                Swap(index, paretIndex);
                index = paretIndex;
            }
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
