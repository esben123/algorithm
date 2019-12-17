using System;
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
            currentSize = 10;
            items = new T[this.currentSize];
        }

        /// <summary>
        /// Append into the list using arrays.
        /// </summary>
        /// <param name="item">Generic item.</param>
        public void Append(T item)
        {
            //If the index is smaller than the size of the array
            if (currentIndex < currentSize)
            {
                items[currentIndex] = item;
                currentIndex++;
                //We add to the end of the array at the current index, and we increase the index.
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
            //To prepend on array, we must move the entire array up one slot. 
            //This requires us to make a new array, and copy old one into the new one.
            //Arrays are immutable, so you can't move items in the array. 
            //We then set the new array to be our current array.
            var newSize = currentSize * increaseSize;
            var newArray = new T[newSize];
            newArray[0] = item;
            items.CopyTo(newArray, 1);
            items = newArray;

        }


        public T[] RemoveAt(T[] source, int index)
        {
            source = items;
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
            //To remove the first item of the array, we have to create a new array.
            //We then move the old one into the new, but start at index 1, so the first item does not get transferred.
            //We then set our newarray to be our current.
            items[0] = item;
            var newArray = new T[currentSize - 1];
            items.CopyTo(newArray, 1);
            items = newArray;
            
        }

        public void RemoveLast()
        {
            Array.Resize(ref items, items.Length - 1);
            //To remove the last item of an array, we can use this method to resize it.
            //Then we don't need to know anything about the last item, since the item will get removed when we resize it. 
        }


    }
}
