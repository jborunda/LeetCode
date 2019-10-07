using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LeetCode
{
    class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode(int x) { value = x; } 

        public void ListAllNodes(ListNode x)
        {
            
            while(x != null)
            {
                Debug.WriteLine(x.value);
                x = x.next;
            }
            
        }
    }
}
