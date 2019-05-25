using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Lession
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public ListNode Add(int x) => next = new ListNode(x);
    }
    class AddTwoNumbersLession : ILession
    {
        public void Execute()
        {
            ListNode node1 = new ListNode(2);
            node1.Add(4);
            ListNode node2 = new ListNode(5);
            node2.Add(6).Add(4);

            //465+42=507->705
            var node3 = AddTwoNumbers(node1, node2);
            var temp = node3;
            do
            {
                Console.Write(temp.val.ToString());
                temp = temp.next;
            }
            while (temp != null);
            Console.Write(";");
        }

        //顺序思路
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode t1 = l1, t2 = l2, r1 = null, r2 = null;
            List<int> a1 = new List<int>(8), a2 = new List<int>(8), amax = null, amin = null;
            do
            {
                a1.Add(t1.val);
                t1 = t1.next;
            } while (t1 != null);
            do
            {
                a2.Add(t2.val);
                t2 = t2.next;
            } while (t2 != null);
            var compare = a1.Count - a2.Count;
            bool up = false;
            int c;
            if (compare >= 0) { amax = a1; amin = a2; }
            else { amax = a2; amin = a1; compare = -compare; }

            c = amax[0] + amin[0];
            r1 = (up = c >= 10) ? new ListNode(c - 10) : new ListNode(c);
            r2 = r1;
            if (amax.Count > 1)
            {
                //[100->10]
                for (int i = 1; i < amax.Count - compare; i++)
                {
                    c = amax[i] + amin[i];
                    if (up) c = c + 1;
                    r2.next = (up = c >= 10) ? new ListNode(c - 10) : new ListNode(c);
                    r2 = r2.next;
                }
                //[10->0]
                for (int i = amax.Count - compare; i < amax.Count; i++)
                {
                    c = amax[i];
                    if (up) c = c + 1;
                    r2.next = (up = c >= 10) ? new ListNode(c - 10) : new ListNode(c);
                    r2 = r2.next;
                }
            }
            if (up) r2.next = new ListNode(1);
            return r1;
        }

        public ListNode AddTwoNumbers_Error(ListNode l1, ListNode l2)
        {
            ListNode t1 = l1, t2 = l2;
            List<int> array = new List<int>(32);
            do
            {
                array.Add(t1.val);
                t1 = t1.next;
            } while (t1 != null);
            int a = 0, b = array.Count, c = 0;
            do
            {
                if (a < b) array[a] += t2.val;
                else array.Add(t2.val);
                a++;
                t2 = t2.next;
            } while (t2 != null);

            ListNode result = null;
            bool up = false;
            c = array[array.Count - 1];
            result = (up = c >= 10) ? new ListNode(c - 10) : new ListNode(c);
            var current = result;
            for (int i = array.Count - 2; i >= 0; i--)
            {
                c = array[i];
                if (up) c = c + 1;
                current.next = (up = c >= 10) ? new ListNode(c - 10) : new ListNode(c);
                current = current.next;
            }
            if (up) current.next = new ListNode(1);
            return result;
        }
    }
}
