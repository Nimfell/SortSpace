using System;
using System.Collections.Generic;

namespace SortSpace
{
  public static class SortLevel
  {
      public static void SelectionSortStep(int[] array, int i)
      {
          int min = i;
          for (int j = i + 1; j < array.Length; j++)          
              if (array[j] < array[min])              
                  min = j;              
          
          if (min != i)
          {
              array[i] = array[i] + array[min];   //x:=x+y;
              array[min] = array[i] - array[min]; //y:=x-y;
              array[i] = array[i] - array[min];   //x:=x-y;   
          }
      }

      public static bool BubbleSortStep(int[] array)
      {
          bool no_changes = true;
          for (int i = 0; i < array.Length-1; i++)
          {              
              if (array[i] > array[i + 1])
              {
                  array[i] = array[i] + array[i + 1];   //x:=x+y;
                  array[i + 1] = array[i] - array[i + 1]; //y:=x-y;
                  array[i] = array[i] - array[i + 1];   //x:=x-y;
                  no_changes = false; 
              }
          }        
          return no_changes;
      }

      public static void Test()
      {
          //============== SELECTION SORT ===================
          int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
          for (int i = 0; i < numbers.Length; i++)
              SortLevel.SelectionSortStep(numbers, i);
          for (int i = 0; i < numbers.Length; i++)
              Console.WriteLine(numbers[i]);
          Console.WriteLine();
          //-------------------------------------------------
          int[] numbers2 = { 4, 3, 2, 1, 0, -1, -2, -3, -4 };
          for (int i = 0; i < numbers2.Length; i++)
              SortLevel.SelectionSortStep(numbers2, i);
          for (int i = 0; i < numbers2.Length; i++)
              Console.WriteLine(numbers2[i]);
          Console.WriteLine();
          //================= BUBLE SORT ====================
          int[] numbers3 = { 4, 3, 2, 1, 0, -1, -2, -3, -4 };

          while (!SortLevel.BubbleSortStep(numbers3)) ;
          for (int i = 0; i < numbers3.Length; i++)
              Console.WriteLine(numbers3[i]);
      }
  }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        SortLevel.Test();
    //        Console.ReadKey(); //pauses for any key 
    //    }    
    //}
}



