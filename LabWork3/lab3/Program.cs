using System;
using System.Collections.Generic;
using library;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareArray squareArr = new SquareArray();
            List<int> array = new List<int>();
            List<int> squarredArray = new List<int>();
            Console.Write("Enter array size: ");
            int arrSize = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < arrSize; i++) {
                Console.Write("Enter [" + (i + 1) + "] value: ");
                int curArr = Convert.ToInt32(Console.ReadLine());
                array.Add(curArr);
            }
            Console.Write("\n\n");
            squarredArray = squareArr.ArrToSquare(array);
            int cnt = 0;
            foreach(var item in squarredArray) {
                // Console.Write(item + " ");
                cnt++;
                Console.WriteLine("Squarred [" + cnt + "] value: " + item);
                
            }
        }
    }
}
