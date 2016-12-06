using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calenderp
{
    class CalendarMemo
    {
        public CalendarMemo(int submittedDay, int submittedMonth, int submittedYear, string submittedMemoTitle, string submittedMemoDescription)
        {
            day = submittedDay;
            month = submittedMonth;
            year = submittedYear;
            memoTitle = submittedMemoTitle;
            memoDescription = submittedMemoDescription;
        }

        int day;
        int month;
        int year;
        string memoTitle;
        string memoDescription;
    }
}
