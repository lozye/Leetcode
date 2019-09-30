using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Lession
{
    public class PriorityHeap<T>
    {
        IComparer<T> _comparer;
        ConcurrentQueue<T> _queue;

        public PriorityHeap(IComparer<T> comparer)
        {
            _comparer = comparer;
            _queue = new ConcurrentQueue<T>();
        }
        public int Count => _queue.Count;
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            SortedDictionary<int, LinkedList<T>> _temp = new SortedDictionary<int, LinkedList<T>>();
    
        }
        public bool TryDequeue(out T value) => _queue.TryDequeue(out value);
        public bool TryPeek(out T value) => _queue.TryPeek(out value);
    }

}
