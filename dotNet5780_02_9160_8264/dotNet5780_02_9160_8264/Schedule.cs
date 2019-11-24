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
        /// function takes care of booking visitors in 
        /// case their request is possible
        /// </summary>
        /// <param name="starting_day">day of arrival</param>
        /// <param name="ending_day">day of departure</param>
        public void Book(Date starting_day, Date ending_day)
        {
            int num_of_nights = ((int)ending_day.MonthIndex - (int)starting_day.MonthIndex) * 31 + (ending_day.DayIndex - starting_day.DayIndex);// calculates the length of visit in nights
            bool allow = true;//is the booking still relevant
            for (int i = 0; i < num_of_nights && allow; i++)
            {
                if (year[((int)starting_day.MonthIndex + (starting_day.DayIndex + i) / 31) % 12, (starting_day.DayIndex + i) % 31])
                {
                    Console.WriteLine("Your request was rejected: atleast one of the days you requested is occupied");
                    allow = false;
                }
            }

            if (allow)
            {
                for (int i = 0; i < num_of_nights; i++)
                {
                    year[((int)starting_day.MonthIndex + (starting_day.DayIndex + i) / 31) % 12, (starting_day.DayIndex + i) % 31] = true;//set day as booked
                }
                Console.WriteLine("Your request was accepted: days {0}.{1} - {2}.{3} are booked for you", starting_day.DayPrint, starting_day.MonthPrint, ending_day.DayPrint, ending_day.MonthPrint);
            }
        }

        /// <summary>
        /// print all sequences of occupied days
        /// </summary>
        public void PrintBookedDays()
        {
            bool foundSequece = false;
            Console.WriteLine("Booked days in the year:");
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (year[i, j] && !foundSequece)//we just found a new sequence
                    {
                        foundSequece = true;
                        Console.Write("{0}.{1} - ", j + 1, (Months)(i + 1));
                    }

                    else if (!year[i, j] && foundSequece)//the end of a sequence
                    {
                        Console.Write("{0}.{1}\n", j + 1, (Months)(i + 1));
                        foundSequece = false;
                    }
                }
            }
            Console.WriteLine();//print an empty line 
        }

        public void NumAndPercentBooked()
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
            Console.WriteLine("Number of booked nights:{0}", numBookedNights);
            Console.WriteLine("Percentage of booked nights:{0}%", ((float)numBookedNights / (31 * 12)) * 100);
        }
    }
}
