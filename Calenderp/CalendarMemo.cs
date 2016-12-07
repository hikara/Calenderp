using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calenderp
{
    public class CalendarMemo
    {
        public CalendarMemo(int submittedDay, int submittedMonth, int submittedYear, string submittedMemoTitle, string submittedMemoDescription)
        {
            day = submittedDay;
            month = submittedMonth;
            year = submittedYear;
            memoTitle = submittedMemoTitle;
            memoDescription = submittedMemoDescription;
        }

        public int day;
        public int month;
        public int year;
        public string memoTitle;
        public string memoDescription;
    }
}
