using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Lession
{
    class FindMedianSortedArraysLession : ILession
    {
        public void Execute()
        {
            var a = FindMedianSortedArrays(new int[] { 1 }, new int[] { 3, 4, 5, 9 });
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int a = nums1.Length + nums2.Length, b = a % 2;
            if (b == 0)
            {


            }
            else
            {
                var c = a / 2;
                int max = nums1[0], x = 0, y = 0;
                for (int i = 0; i < c; i++)
                {
                    if (nums1[x] > nums2[y]) { max = nums1[x]; y++; }
                    else { max = nums2[y]; x++; }
                }
                return max;
            }
            throw new Exception();
        }

    }
}
