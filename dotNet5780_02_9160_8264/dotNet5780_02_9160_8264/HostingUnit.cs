using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_9160_8264
{
    class HostingUnit
    {
        private static int stSerialKey;
        private Schedule diary;

        /// <summary>
        /// default constructor.
        /// set array to false
        /// and HostingUnitKey to stSerialKey.
        /// </summary>
        public HostingUnit()
        {
            HostingUnitKey = stSerialKey;
            diary = new Schedule();
        }
        public int HostingUnitKey
        {
            set
            {
                if (value >= 10000000 && value <= 99999999)
                {
                    HostingUnitKey = value;
                }

                else
                {
                    Console.WriteLine("Error: invalid number");
                }
            }
            get
            {
                return HostingUnitKey;
            }
        }

        public bool[,] Diary
        {
            get;
        }

        public override string ToString()
        {
            return "serial key:" + HostingUnitKey + "\n" + "booked days:\n" + diary.ReturnBookedDaysString();
        }
    }
}