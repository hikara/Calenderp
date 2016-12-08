# Calenderp

https://github.com/hikara/Calenderp

Ben Cline and John Thompson

The program allows the user to add memos and events to a calendar. The user can also view a complete list of all 
notes and memos. The application will save the users state. When clicking on a date, the notes and memos for that
date will be displayed. When an event is entered, a desktop notification will be scheduled to fire when that date
and time occurs, whether the application is open or not. Clicking on the notification will open the app if it is closed.

Known bugs:
Does not open on page that it was closed on. However, it saves all of the relevent data, and it makes sense from a
usability standpoint that the application open back up to the main page when closed, instead of the About page, for
example. Does not resize properly.

John:
Added calendarView, textboxes, textblocks, datepickers, etc. and their respective events. Also the about page, 
and the all memo/events pages.

Ben:
Saving state, AppBar, Navigation, Passing information between pages, various bug fixes, displaying memos and
events on main page, created CalendarMemo and CalendarEvent classes, and desktop notifications.

Percentage: 50/50

Also you wanted us to note that the calendarView is not able to be resized properly. It has a bug that occurs when
it is resized. The bug causes the dates to change if the calendarView is resized. Because of this we don't resize
the calendar.

You also asked for a suggested means of testing. I would recommend adding events and memos to the application, 
click on the dates the memos/events should have been added and seeing if their value is the expected value.
Click the all memos and events page and make sure that you see all of your memos and events. Go back to the home
page and see if the state is the same as when you left. Go to the about page and then go back to the home page to 
see if the state is the same as when you left, and also close the application reopen it, to test if the events and
memos are still available on their days. Set an event for a minute or so (or any reasonable time) later than it is
to test if you receive a toast notification. You can test with the app open or closed for that.
