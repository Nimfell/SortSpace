using System;
using System.Collections.Generic;

namespace SortSpace
{ 
    public class ksort
    {
        public string[] items;
        
        public ksort()
        {
            items = new string[800];
            for (int i = 0; i < items.Length; i++) { items[i] = null; }
        }

        public bool add(string s)
        {   // размещает строку s в массиве items в соответствующей позиции и возвращает true; 
            // а если строка некорректного формата, возвращает false.
            int i = index(s);
            if (i != -1)
            {   items[i] = s;
                return true;
            }
            return false;
        }

        public int index(string s)
        {   // вычисляет индекс строки s в массиве items, или возвращает -1, если строка неверного формата.
            int index = 0;
            if (s.Length != 3) return -1;
            if (!index_plus_delta(ref index, s[0], 97, 8, 100)) return -1; // abcdefgh
            if (!index_plus_delta(ref index, s[1], 48, 10, 10)) return -1;
            if (!index_plus_delta(ref index, s[2], 48, 10,  1)) return -1;
            return index;
        }
		
        private bool index_plus_delta(ref int index, char ch, int begining, int range, int multiplier)
        {
            if ((int)ch >= begining && (int)ch < begining + range)
            {   index += ((int)ch - begining) * multiplier; // если 0, то index = 0
                return true;
            }
            else
                return false;
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int test = 0;
    //        ksort Sort = new ksort();
    //        if (!Sort.add("a00")) test++;
    //        if (Sort.items[0] != "a00") test++;
    //        if (!Sort.add("h99")) test++;
    //        if (Sort.items[799] != "h99") test++;
    //        if (!Sort.add("b04")) test++;
    //        if (Sort.items[104] != "b04") test++;
    //        if (!Sort.add("a01")) test++;
    //        if (Sort.items[1] != "a01") test++;
    //        if (Sort.add("a107")) test++;
    //        if (Sort.add("a2a")) test++;
    //        if (Sort.add("4g5")) test++;
    //    }
    //    static int hashFun(string key)
    //    {
    //        if (key.Length != 3)
    //            return -1;
    //        int index = (int)(key[0] - 97) * 100 + (int)(key[1] - 48) * 10 + (int)(key[2] - 48);
    //        if (index >= 0 && index < 800)
    //            return index;
    //        return -1;
    //    }
    //}
}
