using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Collections
{
    class Queue<T>: SmarterLinkedList<T>
    {
        private SmarterLinkedList<T> list;
        public Queue()
        {
            list = new SmarterLinkedList<T>();
        }

        public void Enqueue(T item)
        {
            list.AddToStart(item);
        }
        public void Dequeue()
        {
            list.RemoveLast();
        }
    }
}