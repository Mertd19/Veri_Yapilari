namespace DataStructures.Heap
{
    public class MinHeap<T> : BinaryHeap<T>, IEnumerable<T> where T : IComparable
    {
        public MinHeap() : base() //base(BHeap) 
        {
            
        }
        public MinHeap(int size) : base(size) 
        {
            
        }
        public MinHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smalllerIndex = GetLeftChildIndex(index);
                if(HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0 ) // Sağ çocuk sol çocuktan küçükse 
                {
                    smalllerIndex = GetRightChildIndex(index);
                }
                if (Array[smalllerIndex].CompareTo(Array[index]) >= 0)
                {
                    break;
                }
                Swap(smalllerIndex, index);
                index = smalllerIndex;
            }
        }

        protected override void HeapifyUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && Array[index].CompareTo(GetParent(index)) < 0 ) 
            {
                var paretIndex = GetParentIndex(index);
                Swap(index, paretIndex);
                index = paretIndex;
            }
        }
    }
}
