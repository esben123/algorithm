using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    
    public class eList<T>
    {
        private class GenericsNode
        {         
            private GenericsNode next;
            private T data;

            public GenericsNode Next { get => next; set => next = value; }
            public T Data { get => data; set => data = value; }


            public GenericsNode(T t)
            {
                next = null;
                data = t;
            }
        }

        private GenericsNode head;

        public eList()
        {
            head = null;
        }

        public void Add(T t)
        {
            GenericsNode n = new GenericsNode(t);
            n.Next = head;
            head = n;
        }

        public void Remove(T t)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            GenericsNode current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
