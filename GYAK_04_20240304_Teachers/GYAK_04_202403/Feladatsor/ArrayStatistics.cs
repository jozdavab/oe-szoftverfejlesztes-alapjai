namespace GYAK_04_202403.Feladatsor
{
    public class ArrayStatistics
    {
        public int[] Array { get; private set; }

        public ArrayStatistics(int[] array)
        {
            Array = array;
        }

        public int Total()
        {
            int sum = 0;
            if (!InvalidArray())
            {
                foreach (int item in Array)
                {
                    sum += item;
                }
            }

            return sum;
        }

        public bool Contains(int number)
        {
            if (!InvalidArray())
            {
                foreach (int item in Array)
                {
                    if (item == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Sorted()
        {
            if (InvalidArray())
            {
                return false;
            }

            for (int i = 0; i < Array.Length - 1; i++)
            {
                if (Array[i] > Array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public int FirstGreater(int number)
        {
            if (!InvalidArray())
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    if (Array[i] > number)
                    {
                        return Array[i];
                    }
                }
            }

            return -1;
        }

        public int CountEvens()
        {
            int counter = 0;
            if (!InvalidArray())
            {
                foreach (int item in Array)
                {
                    if (item % 2 == 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public int MaxIndex()
        {
            if (InvalidArray())
            {
                return -1;
            }

            int maxi = 0;
            for (int i = 1; i < Array.Length; i++)
            {
                if (Array[i] > Array[maxi])
                {
                    maxi = i;
                }
            }

            return maxi;
        }

        public void Sort()
        {
            if (!InvalidArray())
            {
                // Beillesztéses rendezés a  tanultak alapján.
                for (int i = 1; i < Array.Length; i++)
                {
                    int j = i - 1;
                    while (j >= 0 && Array[j] > Array[j + 1])
                    {
                        // Tuple-t is használhatnánk cseréhez, de még nem tanultuk.
                        // (Array[j + 1], Array[j]) = (Array[j], Array[j + 1]);
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                        j--;
                    }
                }
            }
        }

        private bool InvalidArray()
        {
            return Array == null || Array.Length < 1;
        }
    }
}