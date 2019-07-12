﻿using System;
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
              SwapInArray(array, i, min);            
      }

      public static bool BubbleSortStep(int[] array)
      {
          bool no_changes = true;
          for (int i = 0; i < array.Length-1; i++)
          {              
              if (array[i] > array[i + 1])
              {
                  SwapInArray(array, i, i + 1);
                  no_changes = false; 
              }
          }        
          return no_changes;
      }

      public static void InsertionSortStep( int[] array, int step, int i )
      {
          for (int start = i; start < array.Length; start += step) // берём каждый элемент массива
          {
              for (int j = start; j - step >= i; j -= step) // сравниваем с каждым предыдущим элементом массива
              {
                  if (array[j - step] > array[j]) // если                   
                      SwapInArray(array, j, j - step);                  
                  else 
                      break;                  
              }
          }
      }

      public static List<int> KnuthSequence(int array_size)
      {
          List<int> numbers = new List<int>();
          RecList(numbers, array_size, 1);
          return numbers;
      }

      static void RecList(List<int> Array, int array_size, int N)
      {  
          if (N > array_size) return; 
          else
          {   RecList(Array, array_size, 3 * N + 1);
              Array.Add(N);
          }          
      }

      public static int ArrayChunk2(int[] M)
      {
          int N = M[M.Length / 2];
          int i1 = 0;
          int i2 = M.Length - 1;

          while (i1 <= i2)
          {
              while (M[i1] < N)
                  i1++;
              while (M[i2] > N)
                  i2--;

              if (i1 >= i2)
                      break;
              SwapInArray(M, i1, i2);
          }
          return N;

      }

      public static int ArrayChunk(int[] M)
      {
          int N = M[M.Length / 2];
          int i1 = 0;
          int i2 = M.Length - 1;

          while (true)
          {
              while (M[i1] < N)
                  i1++;
              while (M[i2] > N)
                  i2--;

              if (i1 == i2 - 1 && M[i1] > M[i2])
                  SwapInArray(M, i1, i2);
              else
                  if (i1 == i2 || i1 == i2 - 1 && M[i1] < M[i2])
                      break;
              SwapInArray(M, i1, i2);
          }
          return N;
      }


      public static void SwapInArray(int[] a, int i, int j) // поменять местами элементы в массиве
      {
          a[i] = a[i] + a[j];   //x:=x+y;
          a[j] = a[i] - a[j];   //y:=x-y;
          a[i] = a[i] - a[j];   //x:=x-y;
      }

      public static void Test()
      {
          ////============== SELECTION SORT ===================
          //Console.WriteLine("SELECTION SORT");
          //int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
          //for (int i = 0; i < numbers.Length; i++)
          //    SortLevel.SelectionSortStep(numbers, i);
          //PrintArray(numbers);          
          ////-------------------------------------------------
          //int[] numbers2 = { 4, 3, 2, 1, 0, -1, -2, -3, -4 };
          //for (int i = 0; i < numbers2.Length; i++)
          //    SortLevel.SelectionSortStep(numbers2, i);
          //PrintArray(numbers2);  
        
          ////================= BUBLE SORT ====================
          //Console.WriteLine("BUBLE SORT");
          //int[] numbers3 = { 4, 3, 2, 1, 0, -1, -2, -3, -4 };
          //// выполнять пока сортируется
          //while (!SortLevel.BubbleSortStep(numbers3)); 
          //PrintArray(numbers3);

          ////=============== InsertionSortStep ===============
          //Console.WriteLine("InsertionSortStep");
          //int[] numbers4 = { 7, 6, 5, 4, 3, 2, 1 };
          //InsertionSortStep(numbers4, 3, 0);
          //PrintArray(numbers4);  
        
          ////================= KnuthSequence =================
          //Console.WriteLine("KnuthSequence");
          //List<int> List_1 = KnuthSequence(1000);
          //WriteLineItems(List_1);
          //=================== ArrayChunk ====================
          int[] numbers5 = { 7,5,6,4,3,1,2 };
          int n = ArrayChunk2(numbers5);
          PrintArray(numbers5);

      }
      //--------------------- PRINT ---------------------------
      public static void WriteLineItems(List<int> lists)
      {
          foreach (int list in lists)
          { Console.WriteLine(list); } // распечатать список
          Console.WriteLine();
      }

      public static void PrintArray(int[] array)
      {
          for (int i = 0; i < array.Length; i++)
              Console.WriteLine(array[i]);
          Console.WriteLine();
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



