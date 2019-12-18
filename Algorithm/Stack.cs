using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Stack<T>
    {
        //Simple class to create a stack out of our linked list class. Only integrates the needed methods for a stack, thus making the linked list working like a stack.
        private LinkedList<T> list;

        public Stack()
        {
            list = new LinkedList<T>();
        }
        public void Pop(T item)
        {
            list.RemoveFirst();
        }

        public void Push(T item)
        {
            list.Prepend(item);
        }
    }
}
