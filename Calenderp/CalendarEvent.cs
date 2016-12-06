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

        int day;
        int month;
        int year;
        string time;
        string eventTitle;
        //bool reminder
    }
}
