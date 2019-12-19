using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{

    public class LinkedList<T>
    {
        public class LinkedListItem
        {
            public T item;
            public LinkedListItem next; //Reference to the next item
            public LinkedListItem(T item, LinkedListItem next)
            {
                this.item = item;
                this.next = next;
            }
        }
        //The beginning the list
        protected LinkedListItem head;

        /// <summary>
        /// The head of the list is always null at start.
        /// </summary>
        public LinkedList()
        {
            head = null;
        }
        /// <summary>
        /// Returns the length of linked list.
        /// </summary>
        /// <returns></returns>
        private int CalculateLength()
        {
            var current = head; //We set the current item to be the head.
            int count = 0; //The count is set to 0 to begin with.

            //We check if head is null, to check if the list is not empty. If it is null, we return a count of 0.
            if (current == null)
            {
                return 0;
            }

            //We have a reference to the next item in the LinkedListItem class.
            while (current.next != null)
            {
                count++; //We increase the count, since we know that the next item is not null.
                current = current.next; //we then set the current item to be the next item that we referenced to. We continue this, until the next item is null. We then return the count.
            }

            return count;
        }
        /// <summary>
        /// Add to the end of the list. 
        /// </summary>
        /// <param name="item">Item to be added</param>
        public virtual void Add(T item)
        {
            int len = CalculateLength(); //We first find the length of the list through our own method.
            if (head == null)//If the list is empty (no head), we set the new item to be the first item in the list.
            {
                head = new LinkedListItem(item, null); //The next item is null, since this is at the end of the list.
            }
            else
            {
                var current = head; //We set the current item to be the head of the list.
                while (current.next != null) //We follow the next item until it is null, and we find the end of the list.
                {
                    current = current.next;
                }
                //We set next item to be the new item. 
                current.next = new LinkedListItem(item, null);

            }
        }

        public virtual void Remove(T t)
        {
            var current = head;
            if (current == null) //We check if the list is empty
            {
                return; //We exit the method if the list is empty.
            }

            if (current.item.Equals(t))
            {
                if (current.next != null)
                    head = current.next;
                else
                    head = null;
            }

            while (current.next != null)
            {
                if (current.next.item.Equals(t))
                {
                    if (current.next.next != null)
                        current.next = current.next.next;
                    else
                        current.next = null;
                }

                current = current.next;
            }

        }
        /// <summary>
        /// Adds to the start of the 
        /// . 
        /// </summary>
        /// <param name="item"></param>
        public virtual void AddToStart(T item)
        {
            head = new LinkedListItem(item, head); //We set the header to be the new item, and the old head to be the next.
        }
        public virtual int Count => CalculateLength(); //Property to get the length of the list.

        /// <summary>
        /// Removes the first item of the list. 
        /// </summary>
        /// <returns></returns>
        public virtual T RemoveFirst()
        {
            var t = head.item; //Temp variable to get the item connected to the head. 
            head = head.next; //We then set the head to be the next item in the list.
            return t; //We return the first item of the list. 

        }

        public virtual void RemoveLast()
        {
            var current = head;
            if (current == null) //We check if the list is empty
            {
                return; //We exit the method if the list is empty.
            }

            if (current.next == null)
            {
                head = null;
            }

            while (current.next != null)
            {
                if (current.next.next == null)
                {
                    current.next = null;
                    return;
                }
                current = current.next;
            }
        }

        public virtual void Clear()
        {
            head = null;

        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            LinkedListItem current = head;

            while (current != null)
            {
                yield return current.item;
                current = current.next;
            }
        }
    }
}
