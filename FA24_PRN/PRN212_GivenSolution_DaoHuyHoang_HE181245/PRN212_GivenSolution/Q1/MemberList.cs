using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Q1.Program;

namespace Q1
{
    internal class MemberList : ICustomList
    {
        private List<IItem> items = new List<IItem>();
        public int MaximumNumberOfMember { get; set; }

        public event Notify? OnFullOfMember;
        public void Add(IItem item)
        {

            if(items.Count >= MaximumNumberOfMember)
            {
                OnFullOfMember?.Invoke();
                return;
            }
              
                items.Add(item);
                Console.WriteLine("Added successfully");
            
        }

        public void DisplayList()
        {
            foreach (var item in items)
            {
                item.Display();
            }
        }
    }
}
