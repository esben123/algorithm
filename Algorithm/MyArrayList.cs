using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class MyArrayList<T>
    {
        private T[] items;
        int currentIndex = 0;
        int currentSize;
        int increaseSize = 3;

        /// <summary>
        /// Constructor for the ArrayList. Starts with a size of 10.
        /// </summary>
        public MyArrayList()
        {
            this.currentSize = 10;
            this.items = new T[this.currentSize];
        }

        /// <summary>
        /// Append into the list using arrays.
        /// </summary>
        /// <param name="item">Generic item.</param>
        public void Append(T item)
        {
            //If the index is smaller than the size of the list
            if (currentIndex < currentSize)
            {
                this.items[currentIndex] = item;
                this.currentIndex++;
            }
            //If the index is is not smaller than the size, we increase
            //the size of the list by the increaseSize variable.
            else
            {
                var newSize = currentSize * increaseSize;
                //We then create new array with new size and copy the old array into it.
                var newArray = new T[newSize];
                this.items.CopyTo(newArray, 0);
                this.currentSize = newSize;
                //We set our array to be the new array. 
                this.items = newArray;
                //We then continune with putting the index of the new appeneded item, and increasing the index.
                this.items[currentIndex] = item;
                currentIndex++;
            }
        }

        public void Prepend(T item)
        {
            if (currentIndex < currentSize)
            {
                this.items[0] = item;
                this.currentIndex++;
            }
        }

        public static T[] RemoveAt(this T[] source, int index)
        {
            //We create a new array, that is 1 item smaller.
            T[] dest = new T[source.Length - 1];

            //If the index is bigger than 0, we copy the old array into a new one.
            if (index > 0)
            {
                Array.Copy(source, 0, dest, 0, index);
            }
            //If the index is smaller than the new array size
            if (index < source.Length - 1)
            {
                //We copy the source array into the destination array
                Array.Copy(source, index + 1, dest, index, source.Length - 1);
            }

            return dest;
        }
        public void RemoveFirst(T item)
        {
            
        }

        public void RemoveLast(T item)
        {

        }
    }
}
