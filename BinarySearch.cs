using System;
using System.Collections.Generic;

namespace SortSpace
{      
    public class BinarySearch
    {
        public  int[] SortedArray;
        public  int   Right, Left;
        private int   Result; 
       
        public BinarySearch(int[] S_Array)
        {            
            Left = 0;
            Right = S_Array.Length - 1;
            SortedArray = S_Array;
        }

        public void Step(int N) 
        {

            if (Result == 1 || Result == -1) return;
            int middle = (Left + ((Right - Left + 1 ) / 2) ); //делит текущий диапазон на два
            if (N == SortedArray[middle]) 
            {   Result = 1;
                return;
            }
            if (Right == Left) // значение не найдено
            {
                Result = -1;
                return;
            }

            if (N < SortedArray[middle]) 
                Right = middle - 1;   //продолжает сокращение рабочего диапазона, корректируя Left и Right, 
            else                         
                Left = middle + 1;

            Result = 0;
        }

        public int GetResult() { return Result; }

        public int Search(int N)
        {
            int result = 0;
            while (result == 0)
            {   Step(N);
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

    /*
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr_1 = new int[] { -4, -3, -2, -1, 0, 1, 2, 4 };
            BinarySearch Arr = new BinarySearch(arr_1);            
            Console.Write(Arr.Search(-8));
            Arr.Reset();
            Console.Write(Arr.Search(8));
            Arr.Reset();
            Console.Write(Arr.Search(-4));
            Arr.Reset();
            Console.Write(Arr.Search(4));
            Arr.Reset();
            Console.Write(Arr.Search(-2));
            Arr.Reset();            
            Console.Write(Arr.Search(2));            
            Console.WriteLine();
        }        
    }
	*/
}
