using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_9160_8264
{
    /// <summary>
    /// Schedule is an object with 12*31 bool array 
    /// stating whether the day[i][j] is booked
    /// </summary>
    class Schedule
    {
        private bool[,] year;

        /// <summary>
        /// default builder.
        /// set array to false
        /// </summary>
        public Schedule()
        {
            year = new bool[12, 31];
        }

        /// <summary>
        /// calculates a list of the occupied dates
        /// </summary>
        /// <returns>list of occupied dates </returns>
        public string ReturnBookedDaysString()
        {
            string output = String.Empty;//creating the empty string
            bool foundSequece = false;
            //Console.WriteLine("Booked days in the year:");
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (year[i, j] && !foundSequece)//we just found a new sequence
                    {
                        foundSequece = true;
                        //Console.Write("{0}.{1} - ", j + 1, (Months)(i + 1));
                        output += j + 1 + "." + (Months)(i + 1) + " - ";
                    }

                    else if (!year[i, j] && foundSequece)//the end of a sequence
                    {
                        //Console.Write("{0}.{1}\n", j + 1, (Months)(i + 1));
                        output += j + 1 + "." + (Months)(i + 1) + "\n";
                        foundSequece = false;
                    }
                }
            }
            return output;
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            int num_of_nights = ((int)guestReq.ReleaseDate.MonthIndex - (int)guestReq.EntryDate.MonthIndex) * 31 + (guestReq.ReleaseDate.DayIndex - guestReq.EntryDate.DayIndex);// calculates the length of visit in nights
            bool allow = true;//is the booking still relevant
            for (int i = 0; i < num_of_nights && allow; i++)
            {
                if (year[((int)guestReq.EntryDate.MonthIndex + (guestReq.EntryDate.DayIndex + i) / 31) % 12, (guestReq.EntryDate.DayIndex + i) % 31])
                {
                    //Console.WriteLine("Your request was rejected: atleast one of the days you requested is occupied");
                    allow = false;
                }
            }

            if (allow)
            {
                for (int i = 0; i < num_of_nights; i++)
                {
                    year[((int)guestReq.EntryDate.MonthIndex + (guestReq.EntryDate.DayIndex + i) / 31) % 12, (guestReq.EntryDate.DayIndex + i) % 31] = true;//set day as booked
                }
                //Console.WriteLine("Your request was accepted: days {0}.{1} - {2}.{3} are booked for you", guestReq.EntryDate.DayPrint, guestReq.EntryDate.MonthPrint, ending_day.DayPrint, ending_day.MonthPrint);
            }

            guestReq.IsApproved = allow;
            return guestReq.IsApproved;
        }

        public int GetAnnualBusyDays()
        {
            int sum = 0;
            Console.WriteLine("Booked days in the year:");
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (year[i, j])//we just found a new sequence
                    {

                        sum++;
                    }


                }
            }
            return sum;
        }

        public float GetAnnualBusyPercentage()
        {
            int numBookedNights = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (year[i, j])
                    {
                        numBookedNights++;
                    }
                }
            }
            return (numBookedNights / 372);

        }
       
    }
}
