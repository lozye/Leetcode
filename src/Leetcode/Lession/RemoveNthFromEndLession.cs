using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Lession
{
    class RemoveNthFromEndLession : ILession
    {
        public void Execute()
        {
            ListNode x = new ListNode(1);
            ListNode temp = x;
            temp = temp.next = new ListNode(2);
            //temp = temp.next = new ListNode(3);
            //temp = temp.next = new ListNode(4);
            //temp = temp.next = new ListNode(5);
            x = RemoveNthFromEnd(x, 1);
            while (x != null)
            {
                Console.Write(x.val + "->");
                x = x.next;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null) return null;
            ListNode temp = head, current = null;
            int i = -1;
            while (temp != null)
            {
                temp = temp.next;
                if (i == n) current = current.next;
                else if (++i == n) current = head;
            }
            if (current == null) return head.next;
            else current.next = current.next?.next;
            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
