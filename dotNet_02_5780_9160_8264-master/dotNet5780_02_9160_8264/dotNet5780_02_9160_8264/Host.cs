using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_9160_8264
{
    class Host : IEnumerable
    {
        private List<HostingUnit> list;

        public int HostKey
        {
            set;
            get;
        }

        public List<HostingUnit> List
        {
            set
            {
                list = value;
            }

            get
            {
                return list;
            }
        }

        /// <summary>
        /// default builder
        /// </summary>
        /// <param name="id">Host id</param>
        /// <param name="numOfHostingUnits">number of HostingUnits in the Hosts property</param>
        public Host(int id, int numOfHostingUnits)
        {
            HostKey = id;
            list = new List<HostingUnit>(numOfHostingUnits);
        }

        public override string ToString()
        {
            return 
        }

        /// <summary>
        /// finds an empty hosting unit and accepeds requests
        /// </summary>
        /// <param name="guestReq">order request</param>
        /// <returns>returns the HostingUnits HostingUnitKey if accepted, -1 otherwise</returns>
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit item in List)
            {
                if(item.Diary.ApproveRequest(guestReq))//if the request was accepted
                {
                    return item.HostingUnitKey;
                }
            }
            return -1; //else
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < List.Count; i++)
            {
                yield return List[i];
            }
        }
    }
}
