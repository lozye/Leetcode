using System;
using System.IO;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Leetcode.Lession
{
    /// <summary>
    /// 线程安全的异步处理队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IAsyncQueue<T>
    {
        /// <summary>
        /// 开始异步队列处理
        /// </summary>
        /// <param name="invoke">对项的处理</param>
        void Start(Action<T> invoke);
        /// <summary>
        /// 添加一个处理项
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Add(T item);      

    }

    class AsyncQueueDebug
    {

        public static void Start()
        {
            IAsyncQueue<string> queue = new AsyncQueue<string>();
            var desktop = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.log");
            int count = 0;
            queue.Start(x =>
            {
                count++;
                File.AppendAllText(desktop, x, Encoding.UTF8);
                Thread.Sleep(10);
            });

            Func<int, string> invoke = x => $"{DateTime.Now.ToString("HH:mm:ss")}=>{x.ToString()}\r\n";
            Parallel.For(0, 100, x => queue.Add(invoke(x)));
            for (int i = 0; i < 9; i++)
            {
                Task.Factory.StartNew(delegate
                {
                    for (int x = 0; x < 100; x++)
                        queue.Add(invoke(x));
                });
            }
            Console.WriteLine("finish");
            Console.ReadLine();
            while (true) { Console.WriteLine(count); Console.ReadLine(); }

        }
    }

    class AsyncQueue<T> : IAsyncQueue<T>
    {
        ConcurrentQueue<T> _queue;
        Action<T> _invoke;
        int status = 0;
        public bool Add(T item)
        {
            _queue.Enqueue(item);
            if (status != 0) return true;
            if (Interlocked.CompareExchange(ref status, 1, 0) != 0) return true;
            Task.Factory.StartNew(Run);
            return true;
        }

        private void Run()
        {
            while (!_queue.IsEmpty)
            {
                if (!_queue.TryDequeue(out var item)) continue;
                _invoke(item);
            }
            Console.WriteLine("queue is emputy");
            status = 0;
        }

        public void Start(Action<T> invoke)
        {
            if (_invoke != null || invoke == null) return;
            _invoke = invoke;
            _queue = new ConcurrentQueue<T>();
        }
    }
}
