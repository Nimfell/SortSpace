using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class BinarySearch
    {
        int count;
        public int[] SortedArray;
        public int Right, Left;
        private int Result;

        public BinarySearch(int[] S_Array)
        {   Left = 0;
            Right = S_Array.Length - 1;
            SortedArray = S_Array;
        }

        public void Step(int N)
        {   if (Result == 1 || Result == -1) return;
            int middle = (Right + Left) / 2; // делит текущий диапазон на два
            if (N == SortedArray[middle])
            {   Result = 1;
                return;
            }
            if (N < SortedArray[middle])
            {   if (middle == 0) 
                    Right = 0;
                else             
                    Right = middle - 1;   
            }
            else
                Left = middle + 1;
            if (Right == Left) 
            {   if (N == SortedArray[Right])
                {   Result = 1;
                    return;
                }                
                Result = -1;
                return;
            }
            Result = 0;
        }

        public int GetResult() { return Result; }

        public int Search(int N)
        {   count = 0;
            int result = 0;
            while (result == 0)
            {   count++;
                Step(N);               
                result = GetResult();                
            }
            return result;
        }

        public void Reset()
        {   Result = 0;
            Left = 0;
            Right = SortedArray.Length - 1;
        }
    }

    public static class SortLevel
    {
        public static int[] MakeArray(int[] arr, int offset, int length)
        {   int[] slice = new int[length];
            Array.Copy(arr, offset, slice, 0, length);
            return slice;
        }

        public static bool GallopingSearch(int[] array, int key)
        {
            for (int i = 1; i < array.Length; i++)
            {   int index = ((int)Math.Pow(2, i) - 2);
                if (index > array.Length)
                    index = array.Length - 1;
                if (array[index] == key) return true;
                else
                {   if (array[index] > key)
                    {   int Right = index;
                        int Left = ((int)Math.Pow(2, i-1) - 2) + 1;
                        BinarySearch binSearch = new BinarySearch(MakeArray(array, Left, Right - Left + 1));
                        if (binSearch.Search(key) == 1)  return true;
                        else                             return false;
                    }                    
                }
            }
            return false;
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int[] arr_1 = new int[99];
    //        for (int i = 0; i < arr_1.Length; i++)            
    //            arr_1[i] = i + 1;            
    //        Console.WriteLine(SortLevel.GallopingSearch(arr_1, 0));
    //        Console.WriteLine(SortLevel.GallopingSearch(arr_1, 100));
    //        for (int i = 0; i < arr_1.Length; i++)            
    //            Console.WriteLine(SortLevel.GallopingSearch(arr_1, i + 1));
    //    }
    //}	
}