using System;
using System.Collections.Generic;
namespace library
{
    public class SquareArray {
        public List<int> squaredArr;

        public SquareArray()
        {
            
        }
        public List<int> ArrToSquare(List<int> arr) {
            squaredArr = new List<int>();
            for(int i = 0; i < arr.Count; i++) {
                squaredArr.Add(arr[i] * arr[i]);
            }
            return squaredArr;
        }
    }
}