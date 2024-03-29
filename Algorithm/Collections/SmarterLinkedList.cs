﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class SmarterLinkedList<T> : LinkedList<T>
    {
        private LinkedListItem tail; //Always the end. Head = beginning.
        public int count = 0;
        /// <summary>
        /// Appends into the smarter linked list. 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item)
        {
            //If there is no item in the list, we set the head to be the item in method's parameter.
            if (head == null)
            {
                head = new LinkedListItem(item, null);
                tail = head; //We also set the tail to be the head, since the list was empty.
                count++;
            }
            else
            {
                //If the list is not empty, we will set the next item to be the tail, set the next item to be the tail, and increase the count.
                tail.next = new LinkedListItem(item, null);
                tail = tail.next;
                count++;
            }
        }

        public override int Count => count;

        public override void RemoveLast()
        {
            base.RemoveLast();
        }
        public override void AddToStart(T item)
        {
            base.AddToStart(item);
        }
        public override T RemoveFirst()
        {
            return base.RemoveFirst();
        }
       
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Clear()
        {
            base.Clear();
        }
    }
}
