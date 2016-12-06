using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Globalization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calenderp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int selectedYear;
        public int selectedMonth;
        public int selectedDay;
        public string selectedButton = "";
        private string userSubmittedTitle = "No Title Submitted";
        private string userSubmittedMemoText = "No Memo Submitted";
        private string userSubmittedTime = "No Time Submitted";
        private string userSubmittedDate = "No Date Submitted";
        private CalendarMemo currentMemo;
        private CalendarEvent currentEvent;
        private List<CalendarMemo> memoList = new List<CalendarMemo>();
        private List<CalendarEvent> eventList = new List<CalendarEvent>();
        public MainPage()
        {
            this.InitializeComponent();
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-US");
            setSelectedDate(localDate.ToString(culture));
        }

        private void addCalendarPickerText(string calendarPickerType)
        {
            TextBlock calendarPickerText = new TextBlock();
            calendarPickerText.Text = calendarPickerType;
            calendarPickerText.HorizontalAlignment = HorizontalAlignment.Left;
            calendarPickerText.VerticalAlignment = VerticalAlignment.Top;
            calendarPickerText.FontSize = 16;
            calendarPickerText.Height = 30;
            calendarPickerText.Width = 150;
            calendarPickerText.Margin = new Thickness(5, 5, 5, 5);
            datePickerGrid.Children.Add(calendarPickerText);
        }

        private void addCalendarPicker(int year, int month, int day)
        {
            CalendarDatePicker addMemoEventCalendar = new CalendarDatePicker();
            addMemoEventCalendar.Date = new DateTime(year, month, day);
            addMemoEventCalendar.HorizontalAlignment = HorizontalAlignment.Left;
            addMemoEventCalendar.VerticalAlignment = VerticalAlignment.Top;
            addMemoEventCalendar.Margin = new Thickness(105, 5, 5, 5);
            datePickerGrid.Children.Add(addMemoEventCalendar);
            addMemoEventCalendar.DateChanged += addMemoEventCalendar_DateChanged;
        }

        private void addMemoEventCalendar_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            CalendarDatePicker calendarDate = (CalendarDatePicker)sender;
            userSubmittedDate = calendarDate.Date.ToString();
        }

        private void setSelectedDate(string selectedDate)
        {
            int monthDayDelimeter = selectedDate.IndexOf('/');
            selectedMonth = Convert.ToInt32(selectedDate.Substring(0, selectedDate.IndexOf('/')));
            selectedDate = selectedDate.Substring(monthDayDelimeter + 1);

            int dayYearDelimeter = selectedDate.IndexOf('/');
            selectedDay = Convert.ToInt32(selectedDate.Substring(0, dayYearDelimeter));
            selectedDate = selectedDate.Substring(dayYearDelimeter + 1);

            selectedYear = Convert.ToInt32(selectedDate.Substring(0, 4));
        }

        private void addTitle(string titleText)
        {
            TextBlock titleLabel = new TextBlock();
            titleLabel.Text = titleText;
            titleLabel.HorizontalAlignment = HorizontalAlignment.Left;
            titleLabel.VerticalAlignment = VerticalAlignment.Top;
            titleLabel.FontSize = 16;
            titleLabel.Height = 30;
            titleLabel.Width = 150;
            titleLabel.Margin = new Thickness(5, 75, 5, 5);
            addMemoEventGrid.Children.Add(titleLabel);
        }

        private void addUserGivenTitle(string titleType)
        {
            TextBox userGivenTitle = new TextBox();
            userGivenTitle.Text = "Enter A Title For Your " + titleType;
            userGivenTitle.HorizontalAlignment = HorizontalAlignment.Left;
            userGivenTitle.VerticalAlignment = VerticalAlignment.Top;
            userGivenTitle.Height = 30;
            userGivenTitle.Width = 405;
            userGivenTitle.Margin = new Thickness(105, 75, 5, 5);
            userGivenTitle.Background = new SolidColorBrush(Color.FromArgb(255, 48, 179, 221));
            addMemoEventGrid.Children.Add(userGivenTitle);
            userGivenTitle.TextChanged += userGivenTitle_TextChanged;
        }

        private void userGivenTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox userSubmittedChangeTitle = (TextBox)sender;
            userSubmittedTitle = userSubmittedChangeTitle.Text;
        }

        private void addDescriptionlabel()
        {
            TextBlock descriptionLabel = new TextBlock();
            descriptionLabel.Text = "Memo:";
            descriptionLabel.HorizontalAlignment = HorizontalAlignment.Left;
            descriptionLabel.VerticalAlignment = VerticalAlignment.Top;
            descriptionLabel.FontSize = 16;
            descriptionLabel.Height = 30;
            descriptionLabel.Width = 150;
            descriptionLabel.Margin = new Thickness(5, 125, 5, 5);
            addMemoEventGrid.Children.Add(descriptionLabel);
        }

        private void addUserGivenMemo()
        {
            TextBox userGivenMemo = new TextBox();
            userGivenMemo.Text = "Memo";
            userGivenMemo.HorizontalAlignment = HorizontalAlignment.Left;
            userGivenMemo.VerticalAlignment = VerticalAlignment.Top;
            userGivenMemo.Height = 150;
            userGivenMemo.Width = 405;
            userGivenMemo.Margin = new Thickness(105, 125, 5, 5);
            userGivenMemo.Background = new SolidColorBrush(Color.FromArgb(255, 48, 179, 221));
            userGivenMemo.TextWrapping = TextWrapping.Wrap;
            addMemoEventGrid.Children.Add(userGivenMemo);
            userGivenMemo.TextChanged += userGivenMemo_TextChanged;
        }

        private void userGivenMemo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox userSubmittedChangeMemo = (TextBox)sender;
            userSubmittedMemoText = userSubmittedChangeMemo.Text;
        }

        private void addTimePickerText()
        {
            TextBlock calendarPickerText = new TextBlock();
            calendarPickerText.Text = "Event Time:";
            calendarPickerText.HorizontalAlignment = HorizontalAlignment.Left;
            calendarPickerText.VerticalAlignment = VerticalAlignment.Top;
            calendarPickerText.FontSize = 16;
            calendarPickerText.Height = 30;
            calendarPickerText.Width = 150;
            calendarPickerText.Margin = new Thickness(225, 6, 5, 5);
            datePickerGrid.Children.Add(calendarPickerText);
        }

        private void addTimepicker()
        {
            TimePicker eventTime = new TimePicker();
            eventTime.HorizontalAlignment = HorizontalAlignment.Left;
            eventTime.VerticalAlignment = VerticalAlignment.Top;
            eventTime.FontSize = 16;
            eventTime.Margin = new Thickness(315, 5, 5, 5);
            datePickerGrid.Children.Add(eventTime);
            eventTime.TimeChanged += eventTime_TimeChanged;
        }

        private void eventTime_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            TimePicker time = (TimePicker)sender;
            userSubmittedTime = time.Time.ToString();
        }

        private void addSubmitButton(string submissionText)
        {
            Button submitButton = new Button();
            submitButton.Content = submissionText;
            submitButton.HorizontalAlignment = HorizontalAlignment.Center;
            submitButton.VerticalAlignment = VerticalAlignment.Bottom;
            submitButton.Margin = new Thickness(5, 5, 5, 5);
            submitButton.Height = 32;
            submitButton.Width = 130;
            submitButton.Background = new SolidColorBrush(Color.FromArgb(255, 165, 226, 224));
            addMemoEventGrid.Children.Add(submitButton);
            submitButton.Click += submitButton_Click;
        }

        private void addMemoToMemoList()
        {
            if (userSubmittedTitle != "No Title Submitted" 
                && userSubmittedMemoText != "No Memo Submitted" 
                && userSubmittedDate != "No Date Submitted")
            {
                currentMemo = new CalendarMemo(selectedDay, selectedMonth, selectedYear, userSubmittedTitle, userSubmittedMemoText);
                userSubmittedTitle = "No Title Submitted";
                userSubmittedMemoText = "No Memo Submitted";
                userSubmittedDate = "No Date Submitted";
                memoList.Add(currentMemo);
            }
            else
            {
                //rejection messagebox or something
            }
        }

        private void addEventToEventList()
        {
            if (userSubmittedTitle != "No Title Submitted"
                && userSubmittedTime != "No Time Submitted"
                && userSubmittedDate != "No Date Submitted")
            {
                currentEvent = new CalendarEvent(selectedDay, selectedMonth, selectedYear, userSubmittedTime, userSubmittedMemoText);
                userSubmittedTitle = "No Title Submitted";
                userSubmittedTime = "No Time Submitted";
                userSubmittedDate = "No Date Submitted";
                eventList.Add(currentEvent);
            }
            else
            {
                //rejection messagebox or something
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedButton == "Memo")
            {
                addMemoToMemoList();
            }
            else
            {
                addEventToEventList();
            }
        }

        private void removeChildren(Grid grid)
        {
            int count = grid.Children.Count();
            for (int i = 0; i < count; i++)
            {
                grid.Children.RemoveAt(0);
            }
        }

        private void addMemo_Click(object sender, RoutedEventArgs e)
        {
            selectedButton = "Memo";
            removeChildren(addMemoEventGrid);
            removeChildren(datePickerGrid);
            addCalendarPicker(selectedYear, selectedMonth, selectedDay);
            addCalendarPickerText("Memo Date:");
            addTitle("Memo Title:");
            addUserGivenTitle("Memo");
            addDescriptionlabel();
            addUserGivenMemo();
            addSubmitButton("Submit Memo");
        }

        private void addEvent_Click(object sender, RoutedEventArgs e)
        {
            selectedButton = "Event";
            removeChildren(addMemoEventGrid);
            removeChildren(datePickerGrid);
            addCalendarPicker(selectedYear, selectedMonth, selectedDay);
            addCalendarPickerText("Event Date:");
            addTitle("Event Title:");
            addUserGivenTitle("Event");
            addTimepicker();
            addTimePickerText();
            addSubmitButton("Submit Event");
        }

        private void setDatePicker()
        {
            if (datePickerGrid.Children.Count > 0)
            {
                removeChildren(datePickerGrid);
                addCalendarPicker(selectedYear, selectedMonth, selectedDay);
                addCalendarPickerText(selectedButton + " Date:");
                if (selectedButton == "Event")
                {
                    addTimepicker();
                    addTimePickerText();
                }
            }
        }

        private void calenderpCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {            
            foreach (DateTimeOffset date in sender.SelectedDates)
            {
                string currentSubmittedDate = date.ToString();
                setSelectedDate(currentSubmittedDate);
                setDatePicker();

            }
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            //Save State
            this.Frame.Navigate(typeof(AboutPage));
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            //Save State
            this.Frame.Navigate(typeof(SettingsPage));
        }
    }

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

        int day;
        int month;
        int year;
        string memoTitle;
        string memoDescription;
    }
}
