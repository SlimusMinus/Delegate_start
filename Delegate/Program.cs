using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;


namespace Delegate
{
    public delegate void DelegateInt(ref int[] ints);
    internal class Program
    {
        public static void EvenNumbers(ref int[] ints)
        {
            int size = 0;
            int[] new_ints = new int[ints.Length];
            int j = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i]%2 != 0)
                {
                    new_ints[j] = ints[i];
                    j++;
                    ++size;
                }
            }
            Array.Resize(ref new_ints, size);
            ints = new_ints;
            WriteLine("Вывод в консоль нечетных чисел массива");
            for (int i = 0; i < new_ints.Length; i++)
            {
                Write(ints[i] + " ");
            }
            WriteLine();
            WriteLine("**************************************");
        }
        public static void SumNumbers(ref int[] ints)
        {
            WriteLine("Сумма всех нечетных чисел массива");
            int summ = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                summ += ints[i];
            }
            WriteLine(summ);
            WriteLine("**************************************");

        }
        public static void MultNumbers(ref int[] ints)
        {
            WriteLine("Сортировка всех нечетных чисел массива");

            for (int i = 0; i < ints.Length; i++)
            {
                for (int j = 0; j < ints.Length - i - 1; j++)
                {
                    if (ints[j] > ints[j+1])
                    {
                        int k = ints[j];
                        ints[j] = ints[j+1];
                        ints[j+1] = k;
                    }
                }
            }
            for (int i = 0; i < ints.Length; i++)
            {
                Write(ints[i] + " ");
            }
            WriteLine();
            WriteLine("**************************************");

        }

        static void Main(string[] args)
        {
            int[] ints = { 99, 11, 103, 1188, 7, 8, 9, 78, 88, 13, 25, 66, 19};
            WriteLine("Вывод в консоль всех чисел массива");
            foreach (var item in ints)
            {
                Write(item + " ");
            }
            WriteLine();
            WriteLine("**************************************");
            DelegateInt d1 = null;
            DelegateInt d2 = new DelegateInt(ref EvenNumbers);
            DelegateInt d3 = new DelegateInt(ref SumNumbers);
            DelegateInt d4 = new DelegateInt(ref MultNumbers);
            d1 = d2 + d3 + d4;
            d1(ref ints);
           

        }
    }
}
