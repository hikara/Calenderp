using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calenderp
{
    public class CalendarEvent
    {
        public CalendarEvent(int submittedDay, int submittedMonth, int submittedYear, string submittedTime, string submittedEventTitle)
        {
            day = submittedDay;
            month = submittedMonth;
            year = submittedYear;
            time = submittedTime;
            eventTitle = submittedEventTitle;
        }

        public int day;
        public int month;
        public int year;
        public string time;
        public string eventTitle;
        //bool reminder
    }
}
