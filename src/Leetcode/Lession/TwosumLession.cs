using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Lession
{
    class TwosumLession : ILession
    {
        public void Execute()
        {
            TwoSum(new int[] { -3, 3, 5, 6, 77 }, 0);
        }
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>(nums.Length);
            int a, y;
            for (int i = 0; i < nums.Length; i++)
            {
                var item = nums[i];
                //if (a < 0) continue;
                if (map.TryGetValue(item, out y))
                    return new int[] { y, i };
                a = target - item;
                map[a] = i;
            }
            return new int[] { -1, -1 };
        }
    }
}
