using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_9160_8264
{
    class GuestRequest
    {
        Date entryDate;
        Date releaseDate;
        bool isApproved;

        public Date EntryDate
        {
            get;
        }

        public Date ReleaseDate
        {
            get;
        }

        public bool IsApproved
        {
            set;
            get;
        }

        public override string ToString()
        {
            return "entry date:" + EntryDate + "\nrelease date:" + ReleaseDate + "\nisapproved:" + IsApproved;
        }

        public void func1()
        {
            Console.WriteLine(entryDate);
        }
        
    }
}

