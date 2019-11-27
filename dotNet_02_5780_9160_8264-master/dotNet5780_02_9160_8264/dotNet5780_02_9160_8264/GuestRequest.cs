using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_9160_8264
{
    class GuestRequest
    {

        public GuestRequest(Date entry, Date release)
        {
            EntryDate = entry;
            ReleaseDate = release;
        }

        /// <summary>
        /// begining of Hosting
        /// </summary>
        public Date EntryDate
        {
            get;
        }

        /// <summary>
        /// end of Hosting
        /// </summary>
        public Date ReleaseDate
        {
            get;
        }

        /// <summary>
        /// is the request approved
        /// </summary>
        public bool IsApproved
        {
            set;
            get;
        }

        public override string ToString()
        {
            return "entry date:" + EntryDate + "\nrelease date:" + ReleaseDate + "\nisapproved:" + IsApproved;
        }
    }
}

