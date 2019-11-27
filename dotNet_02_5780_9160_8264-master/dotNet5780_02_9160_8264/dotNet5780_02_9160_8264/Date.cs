using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_9160_8264
{
    enum Months
    {
        Zero = -1,

        January = 1,
        Febuary,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December

    }

    class Date
    {
        private int day;
        private Months month;
        private int year;


        /// <summary>
        /// used for getting the 2d array indexes
        /// </summary>
        public int DayIndex
        {
            set
            {
                if (value >= 0 && value <= 30)//day indexes are 0-30
                {
                    day = value +1;
                }

                else
                {
                    day = -1;
                }

            }

            get
            {
                return day - 1;
            }

        }

        /// <summary>
        /// used to print the date
        /// or set the date 
        /// </summary>
        public int DayPrint
        {
            set
            {
                if (value >= 1 && value <= 31)//day is 1-31
                {
                    day = value;
                }

                else
                {
                    day = -1;
                }

            }
            get
            {
                return day;
            }
        }

        /// <summary>
        /// used for 2d array indexes
        /// </summary>
        public Months MonthIndex
        {
            set
            {
                if (value >= Months.January -1 && value <= Months.December -1)//if month is 0-11
                {
                    month = value + 1;
                }
                /*else if(value == (Months)12)//if month is 12
                {
                    month = Months.December;
                }*/
                else
                {
                    month = Months.Zero;
                }
            }

            get
            {
                return month - 1;
            }
        }

        /// <summary>
        /// used when printing the date
        /// or when setting date
        /// </summary>
        public Months MonthPrint
        {
            set
            {
                if (value >= Months.January && value <= Months.December)//if month is 1-12
                {
                    month = value;
                }
                /*else if(value == (Months)12)//if month is 12
                {
                    month = Months.December;
                }*/
                else
                {
                    month = Months.Zero;
                }
            }
            get
            {
                return month;
            }
        }

        /// <summary>
        /// used to print the year
        /// </summary>
        public int YearPrint
        {
            set
            {
                if (value >= 0)//day is 2000-2020
                {
                    year = value;
                }

                else
                {
                    year = -1;
                }

            }
            get
            {
                return year;
            }
        }

            
            

        /// <summary>
        /// Date builder gets two paramarters and sets month and day to input.
        /// </summary>
        /// <param name="nDay">Day of the month.</param>
        /// <param name="nMonth">Name of the month.</param>
        /// <param name="nYear">Num of year.</param>
        public Date(int nDay, Months nMonth, int nYear)
        {
            DayPrint = nDay;
            MonthPrint = nMonth;
            YearPrint = nYear;
        }

        public Date()
        {
            DayPrint = -1;
            MonthPrint = Months.Zero;
            YearPrint = -1;
        }

        /// <summary>
        /// make sure the date is valid
        /// </summary>
        /// <returns>true if yes false otherwise</returns>
        public bool DateIsValid()
        {
            if (month == Months.Zero || day == -1 || year==-1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// used for printing the date by ConsoleWrite
        /// </summary>
        /// <returns>the date in string format</returns>
        public override string ToString()
        {
            return DayPrint + "." + MonthPrint + "." + YearPrint;
        }

        public static Date operator +(Date start, int length)
        {
            Date end = new Date();

            if (end.DayIndex + length > 30)//if the day addition gets us to the next month
            {
                end.MonthIndex = (Months)(((int)end.MonthIndex + 1) % 12);
                if (end.MonthPrint == Months.January)//if we started a new year
                {
                    end.YearPrint++;
                }
            }
            end.DayIndex = (end.DayIndex + length) % 31;//add the days to the starting date
            return end;
        }
    }
}

