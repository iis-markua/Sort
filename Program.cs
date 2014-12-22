using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputStr;
            string[] arrayStr = new string[20];
            Sort so = new Sort();
            int q = 0;
            Console.WriteLine("pls input less than 20 numbers, split by spaces");
            inputStr = Console.ReadLine();
            arrayStr = inputStr.Split(' ');
            int[] array = new int[arrayStr.Length];
            while(q < arrayStr.Length){
                array[q] = int.Parse(arrayStr[q]);
                q++;
            }
            Console.WriteLine("Type 'B' for BubbleSort, 'SL' for SelectionSort, 'Q' for QuickSort, 'M' for MergeSort, 'SH' for shellsort");
            int[] arrayFinal = new int[q];
            arrayFinal = so.SelectionSort(array);
            for (int k = 0; k < q; k++)
            {
                Console.WriteLine(arrayFinal[k]);
            }

            Console.ReadLine();
        }

        

    }

    class Sort
    {
        public int[] BubbleSort(int[] param)
        {
            for (int i = 0; i < param.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (param[j] > param[i])
                    {
                        int temp = param[j];
                        param[j] = param[i];
                        param[i] = temp;
                    }
                }
            }
            return param;
        }

        public int[] SelectionSort(int[] param)
        {
            for (int i = 0; i < param.Length - 1; i++)
            {
                for (int j = i + 1; j < param.Length; j++)
                {
                    if (param[j] < param[i])
                    {
                        int temp = param[j];
                        param[j] = param[i];
                        param[i] = temp;
                    }
                }
            }
            return param;
        }

        public int[] MergeSort(int[] param)
        {
            int middle;
            middle = param.Length / 2;
            if (param.Length == 1)
                return param;
            int[] subParam1 = new int[middle];
            int[] left = new int[middle];
            int[] subParam2 = new int[param.Length - middle];
            int[] right = new int[param.Length - middle];
            for (int i = 0; i < middle; i++)
            {
                subParam1[i] = param[i];
            }
            for (int j = middle; j < param.Length; j++)
            {
                subParam2[j - middle] = param[j];
            }
            left = MergeSort(subParam1);
            right = MergeSort(subParam2);
            return Merger(left, right);
        }

        public int[] Merger(int[] param1, int[] param2)
        {
            int[] param = new int[param1.Length + param2.Length];
            int i = 0;
            int j = 0;
            int l = 0;
            while (i < param1.Length && j < param2.Length)
            {
                if (param1[i] < param2[j])
                {
                    param[l] = param1[i];
                    i++;
                    l++;
                }
                else
                {
                    param[l] = param2[j];
                    j++;
                    l++;
                }
            }
            if (i < param1.Length)
            {
                while (l < param.Length)
                {
                    param[l] = param1[i];
                    l++;
                    i++;
                }
            }
            if (j < param2.Length)
            {
                j += 1;
                l += 1;
                while (l < param.Length)
                {
                    param[l] = param2[j];
                }
            }
            return param;
        }
    }
}
