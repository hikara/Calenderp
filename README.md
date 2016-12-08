# Calenderp

https://github.com/hikara/Calenderp

Ben Cline and John Thompson

The program allows the user to add memos and events to a calendar. The user can also view a complete list of all 
notes and memos. The application will save the users state. When clicking on a date, the notes and memos for that
date will be displayed.

Known bugs:
Does not open on page that it was closed on.
Does not display something on the respective date on the calendarView after a memo or event is added. (Something 
we planned on implementing)
Does not resize properly.

John:
Added calendarView, textboxes, textblocks, datepickers, etc. and their respective events. Also the about page, 
and the all memo/events pages.

Ben:
Saving state, AppBar, Navigation, Passing information between pages, various bug fixes, displaying memos and
events on main page, created CalendarMemo and CalendarEvent classes.

Percentage: 50/50

Also you wanted us to note that the calendarView is not able to be resized properly. It has a bug that occurs when
it is resized. The bug causes the dates to change if the calendarView is resized. Because of this we don't resize
the calendar.

You also asked for a suggested means of testing. I would recommend adding events and memos to the application, 
click on the dates the memos/events should have been added and seeing if their value is the expected value.
Click the all memos and events page and make sure that you see all of your memos and events. Go back to the home
page and see if the state is the same as when you left. Go to the about page and then go back to the home page to 
see if the state is the same as when you left.
