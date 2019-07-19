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
      //=========================== ShellSort ============================
      public static void ShellSort(int[] A)
      {
          List<int> Steps = KnuthSequence(A.Length); // создали список шагов          
          foreach (int step in Steps)                // проходим
          {
              for (int s = 0; (s < step) && (s + step < A.Length); s++)
                  InsertionSortStep(A, step, s); 
          } 
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

      public static List<int> KnuthSequence(int array_size) // РАСЧЕТ ШАГА
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
      //========================= Quicksort ============================
      public static void quicksort(int[] a, int l, int r)
      {
          if (l < r)
          {
              int q = partition(a, l, r);
              quicksort(a, l, q);
              quicksort(a, (q + 1), r);
          }
      }

      public static int partition(int[] M, int i, int j)
      {
          
          int N = M[(i + j)>>1];
          int i1 = i;
          int i2 = j;

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
          return i2;
      }
      //========================== Quicksort2 ===============================
      public static void QuickSortTailOptimization(int[] tab, int left, int right)
      {
          int N;
          while (left < right) // сортируем оставшуюся часть
          {
              N = ArrayChunk(tab, left, right);
              if (N - left < right - N)               // определяем меньшую половину
              {
                  QuickSortTailOptimization(tab, left, N - 1);   // рекурсия
                  left = N + 1;                   // слева всё отсортировано, поэтому смещаем 
              }                                // крайний левый индикатор вправо на один от опорного элемента
              else
              {
                  QuickSortTailOptimization(tab, N + 1, right);   // рекурсия
                  right = N - 1;                   // справа всё отсортировано, поэтому смещаем 
              }                                // крайний правый индикатор влево на один от опорного элемента
          }
      }

      public static void QuickSort(int[] array, int left, int right) // не доделан
      {
          if (left < right)
          {
              int N = ArrayChunk(array, left, right);
              QuickSort(array, left, N - 1);
              QuickSort(array, N + 1, right);
          }
      }

      public static int N; //разделитель (глобальный - чёрт чёрт чёрт...)
      public static int ArrayChunk(int[] M, int left, int right)
      {
          N = M[(left + right) >> 1];     //[M.Length / 2];
          int i1 = left;                      //0;
          int i2 = right;                     // M.Length - 1;

          while (i1 <= i2) //i1 <= i2
          {
              while (M[i1] < N)
                  i1++;
              while (M[i2] > N)
                  i2--;

              if (i1 == i2 - 1 && M[i1] > M[i2])
              {
                  SwapInArray(M, i1, i2);
                  return ArrayChunk(M, left, right);
              }
              else
              {
                  if (i1 == i2 || (i1 == i2 - 1 && M[i1] < M[i2]))
                      break;
                  else
                      SwapInArray(M, i1, i2);
              }
          }
          return i2;
      }

      public static List<int> KthOrderStatisticsStep0(int[] Array, int L, int R, int k)
      {
          N = ArrayChunk(Array, L, R);
          if (N == k)
          {
              List<int> list = new List<int>();
              list.Add(L);
              list.Add(R);
              return list;
          }
          if (N < k)
              L = N;
          else
              R = N;
          return KthOrderStatisticsStep0(Array, L, R, k);
      }
      //-------------------------------------------------------------------------------
      //------ на шаг ближе к k ------

      public static List<int> KthOrderStatisticsStep(int[] Array, int L, int R, int k)
      {
          N = ArrayChunk(Array, L, R);
          List<int> list = new List<int>();
          if (N < k)
              L = N;
          else
              R = N;
          list.Add(L);
          list.Add(R);
          return list;          
      }
      //------ достижение k ------
      public static List<int> StatisticsStep(int[] Array, int L, int R, int k)
      {
          List<int> list = KthOrderStatisticsStep(Array, L, R, k);
          L = list[0];
          R = list[1];
          //int N = (L + R) >> 1;  // опорный элемент 
          return StatisticsStep(Array, L, R, k);
      }

      //------ сортировка с k ------
      public static void QuickSortMed(int[] A, int L, int R)
      {
          while (L < R) // сортируем оставшуюся часть
          {
              int k = (L + R) >> 1;            // индекс центра
              StatisticsStep(A, L, R, k); // нашли диапазон, где центр - это медиана
              //int N = (L + R) >> 1;               
              if (N - L < R - N)               // определяем меньшую половину
              {
                  QuickSortMed(A, L, N - 1);   
                  L = N + 1;                   // слева всё отсортировано, поэтому смещаем 
              }                                // крайний левый индикатор вправо на один от опорного элемента
              else
              {
                  QuickSortMed(A, N + 1, R);   
                  R = N - 1;                   // справа всё отсортировано, поэтому смещаем 
              }                                // крайний правый индикатор влево на один от опорного элемента
          }
      }
      //-------------------------------------------------------------------------------
      public static void qsort(int[] A, int l, int r) 
      {
          int i, j;
          int t, x;
          i = l; // левый
          j = r; // правый
          x = A[(l + r) / 2]; // медиана ? опорный
          do
          {
              while (A[i] < x) i++;  
              while (A[j] > x) j--;
              if (i <= j)
              {
                  t = A[i];
                  A[i] = A[j];
                  A[j] = t;
                  i++; j--;
              }
          } while (i <= j);
          if (l < j) qsort(A, l, j);
          if (i < r) qsort(A, i, r);
      }
      //===================================================================
      public static void SwapInArray(int[] a, int i, int j) // поменять местами элементы в массиве
      {
          a[i] = a[i] + a[j];   //x:=x+y;
          a[j] = a[i] - a[j];   //y:=x-y;
          a[i] = a[i] - a[j];   //x:=x-y;
      }

      //--------------------- PRINT ---------------------------
      public static void WriteListItems(List<int> lists)
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
      //---------------------- TEST ----------------------------
      public static void Test()
      {                          /*
          //============== SELECTION SORT ===================
          Console.WriteLine("SELECTION SORT");
          int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
          for (int i = 0; i < numbers.Length; i++)
              SortLevel.SelectionSortStep(numbers, i);
          PrintArray(numbers);          
          //-------------------------------------------------
          int[] numbers2 = { 4, 3, 2, 1, 0, -1, -2, -3, -4 };
          for (int i = 0; i < numbers2.Length; i++)
              SortLevel.SelectionSortStep(numbers2, i);
          PrintArray(numbers2);  
        
          //================= BUBLE SORT ====================
          Console.WriteLine("BUBLE SORT");
          int[] numbers3 = { 4, 3, 2, 1, 0, -1, -2, -3, -4 };
          // выполнять пока сортируется
          while (!SortLevel.BubbleSortStep(numbers3)); 
          PrintArray(numbers3);

          //=============== InsertionSortStep ===============
          Console.WriteLine("InsertionSortStep");
          int[] numbers4 = { 7, 6, 5, 4, 3, 2, 1 };
          InsertionSortStep(numbers4, 3, 0);
          PrintArray(numbers4);  
          Console.WriteLine();
          //--------------------------------------
          int[] numbers5 = { 11, 7, 6, 5, 15, 12 ,9 ,4, 14, 3, 2, 1 , 16, 8, 10, 13};         
          ShellSort(numbers5);
          PrintArray(numbers5); 
          
          //================= KnuthSequence =================
          Console.WriteLine("KnuthSequence");
          List<int> List_1 = KnuthSequence(1000);
          WriteLineItems(List_1);
          //=================== ArrayChunk ====================
          int[] a = { 7, 5, 6, 4, 3, 1, 2 };
          partition(a, 0, 6);          
          PrintArray(a);
          //-----------
          int[] b = { 6, 5, 7 };
          int t = ArrayChunk(b,0,2);
          Console.WriteLine(t);
          Console.WriteLine();
          PrintArray(b);          */
          //================== Quicksort ======================
          //int[] Arr = { 11, 7, 6, 1, 15, 12, 9, 5, 14, 3, 2, 8, 16, 4, 10, 13 };
          //QuickSortMed(Arr, 0, Arr.Length - 1);
          //List<int> listC = KthOrderStatisticsStep(Arr, 0, Arr.Length - 1, (0 + Arr.Length - 1) >> 1);
          //PrintArray(Arr);
          //WriteListItems(listC);
       
          //================== Factorial ======================
         // Console.WriteLine(factorial(5, 1));

          //================== KthOrderStatisticsStep =================
          //int[] A = { 5, 6, 7, 4, 1, 2, 3 };
          //List<int> list = KthOrderStatisticsStep(A, 0, A.Length - 1, 3);
          //PrintArray(A);
          //WriteListItems(list);

          int[] B = { 5, 6, 7, 4, 1, 2, 3 };
          List<int> listB = KthOrderStatisticsStep(B, 0, B.Length - 1, 0);
          PrintArray(B);
          WriteListItems(listB);

      }
    public static int factorial(int n, int a)
    {
        if(n < 0)  return 0; // если отрицательное
        if(n == 0) return 1; // если n = 0
        if(n == 1) return a; // когда n равно или стало единицей
        return factorial(n - 1, n * a); // вход если n > 1, a = 1 в первый раз
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



