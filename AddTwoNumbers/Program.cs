using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    internal class Program
    {
        private static void Main()
        {
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode trav = null;

            var carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                var digit1 = l1 != null ? l1.val : 0;
                var digit2 = l2 != null ? l2.val : 0;

                var sum = digit1 + digit2 + carry;
                var digit3 = sum % 10;

                if (head == null)
                {
                    head = trav = new ListNode(digit3);
                }
                else
                {
                    trav.next = new ListNode(digit3);
                    trav = trav.next;
                }

                carry = sum / 10;

                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }

            return head;
        }
    }
}
