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
        {
            Left = 0;
            Right = S_Array.Length - 1;
            SortedArray = S_Array;
        }

        public void Step(int N)
        {
            if (Result == 1 || Result == -1) return;
            int middle = (Right - ((Right - Left + 1) / 2)); //делит текущий диапазон на два
            //Console.WriteLine("  Middle = " + middle);
            //Console.WriteLine("  Items  = " + (Right - Left + 1) );
            if (N == SortedArray[middle])
            {   Result = 1;
                return;
            }
            if (Right == Left) // значение не найдено
            {   Result = -1;
                return;
            }
            if (N < SortedArray[middle])
            {   if (middle == 0) Right = 0;
                else Right = middle - 1;   //продолжает сокращение рабочего диапазона, корректируя Left и Right,
            }
            else
                Left = middle + 1;
            Result = 0;
        }

        public int GetResult() { return Result; }

        public int Search(int N)
        {
            count = 0;
            int result = 0;
            while (result == 0)
            {
                count++;
                //Console.WriteLine("  Step: " + count);
                //Console.WriteLine("  Left   = " + Left);
                //Console.WriteLine("  Right  = " + Right);
                //Console.WriteLine();
                Step(N);
                result = GetResult();                
            }
            return result;
        }

        public void Reset()
        {
            Result = 0;
            Left = 0;
            Right = SortedArray.Length - 1;
        }
    }
    
    //class Program
    //{
    //    static void Main(string[] args)
    //    {   
    //        int[] arr_1 = new int[99];

    //        for (int i = 0; i < arr_1.Length; i++ )
    //        {
    //            arr_1[i] = i + 1;
    //        }
    //        BinarySearch Arr = new BinarySearch(arr_1);            
    //        //Console.Write(Arr.Search(49));
    //        //Arr.Reset();
    //        Console.WriteLine(Arr.Search(100));
    //        Arr.Reset();
    //        Console.WriteLine(Arr.Search(-1));
    //        Arr.Reset();
    //        Console.WriteLine(Arr.Search(99));
    //        Arr.Reset();
    //        Console.WriteLine(Arr.Search(1));
    //        Arr.Reset();
    //        Console.WriteLine(Arr.Search(2));
    //    }        
    //}	
}