namespace GYAK_04_202403.Feladatsor
{
    public class Stack
    {
        private int[] items;
        public int Count { get; private set; }

        public Stack(int maxSize)
        {
            if (maxSize < 1)
            {
                // Nem tanultunk még kivételkezelést, úgyhogy marad az egy elemre való defaultálás.
                maxSize = 1;
            }
            items = new int[maxSize];
        }

        public bool Push(int newItem)
        {
            if (Count == items.Length)
            {
                return false;
            }
            items[Count++] = newItem;
            return true;
        }

        public bool Pop(out int item)
        {
            if (Count == 0)
            {
                item = 0;
                return false;
            }
            item = items[--Count];
            return true;
        }

        public bool Empty()
        {
            return Count == 0;
        }

        public bool Full()
        {
            return Count == items.Length;
        }
    }
}