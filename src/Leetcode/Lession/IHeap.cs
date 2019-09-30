namespace Leetcode.Lession
{
    interface IHeap<T>
    {
        int Count { get; }
        void Enqueue(T item);
        bool TryPeek(out T value);
        bool TryDequeue(out T value);
    }
}
