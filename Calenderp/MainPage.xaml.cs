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
using Windows.UI.Popups;
using Newtonsoft.Json;
using Windows.Storage;

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
        public List<CalendarMemo> memoList = new List<CalendarMemo>();
        public List<CalendarEvent> eventList = new List<CalendarEvent>();

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
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
            if (((CalendarDatePicker)sender).Date.ToString() != "")
            {
                CalendarDatePicker calendarDate = (CalendarDatePicker)sender;
                userSubmittedDate = calendarDate.Date.ToString();
                setSelectedDate(userSubmittedDate);
            }
            else
            {
                datePickerGrid.Children.RemoveAt(0);
                datePickerGrid.Children.RemoveAt(0);
                addCalendarPickerText(selectedButton + " Date:");
                addCalendarPicker(selectedYear, selectedMonth, selectedDay);
            }
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

        private async void showErrorMessage(string message)
        {
            var dialog = new MessageDialog(message, "Error");
            await dialog.ShowAsync();
        }

        private void addMemoToMemoList()
        {
            currentMemo = new CalendarMemo(selectedDay, selectedMonth, selectedYear, userSubmittedTitle, userSubmittedMemoText);
            memoList.Add(currentMemo);
        }

        private void addEventToEventList()
        {
            currentEvent = new CalendarEvent(selectedDay, selectedMonth, selectedYear, userSubmittedTime, userSubmittedTitle);
            eventList.Add(currentEvent);
        }

        private void addResponse(string response)
        {
            TextBlock responseText = new TextBlock();
            responseText.Text = response;
            responseText.HorizontalAlignment = HorizontalAlignment.Left;
            responseText.VerticalAlignment = VerticalAlignment.Top;
            responseText.FontSize = 16;
            responseText.Height = 30;
            responseText.Width = 405;
            responseText.Margin = new Thickness(5, 75, 5, 5);
            addMemoEventGrid.Children.Add(responseText);
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            removeChildren(addMemoEventGrid);
            removeChildren(datePickerGrid);
            if (selectedButton == "Memo")
            {
                addMemoToMemoList();
                addResponse("Memo successfully submitted.");
            }
            else
            {
                addEventToEventList();
                addResponse("Event successfully submitted.");
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

        private List<List<string>> generateDateSelectedStringsEvents()
        {
            List<List<string>> returnValue = new List<List<string>>();

            foreach (CalendarEvent ev in eventList)
            {
                List<string> list = new List<string>();
                list.Add(ev.day.ToString());
                list.Add(ev.month.ToString());
                list.Add(ev.year.ToString());
                list.Add(ev.eventTitle);
                list.Add(ev.time);
                returnValue.Add(list);
            }

            return returnValue;
        }

        private List<List<string>> generateDateSelectedStringsMemos()
        {
            List<List<string>> returnValue = new List<List<string>>();

            foreach (CalendarMemo mem in memoList)
            {
                List<string> list = new List<string>();
                list.Add(mem.day.ToString());
                list.Add(mem.month.ToString());
                list.Add(mem.year.ToString());
                list.Add(mem.memoTitle);
                list.Add(mem.memoDescription);
                returnValue.Add(list);
            }

            return returnValue;
        }

        private void generateDateSelectedTextBlocks()
        {
            List<List<string>> info = generateDateSelectedStringsEvents();
            selectedDateMemosAndEvents.Text = "";
            foreach (List<string> lst in info)
            {
                if (selectedYear == Convert.ToInt32(lst[2]) && selectedMonth == Convert.ToInt32(lst[1]) && selectedDay == Convert.ToInt32(lst[0]))
                {
                    selectedDateMemosAndEvents.Text += "Title: " + lst[3] + "\n";
                    selectedDateMemosAndEvents.Text += "Day: " + lst[0] + "\n";
                    selectedDateMemosAndEvents.Text += "Month: " + lst[1] + "\n";
                    selectedDateMemosAndEvents.Text += "Year: " + lst[2] + "\n";
                    selectedDateMemosAndEvents.Text += "Time: " + lst[4] + "\n\n";
                }
            }
            info = generateDateSelectedStringsMemos();
            foreach (List<string> lst in info)
            {
                if (selectedYear == Convert.ToInt32(lst[2]) && selectedMonth == Convert.ToInt32(lst[1]) && selectedDay == Convert.ToInt32(lst[0]))
                {
                    selectedDateMemosAndEvents.Text += "Title: " + lst[3] + "\n";
                    selectedDateMemosAndEvents.Text += "Day: " + lst[0] + "\n";
                    selectedDateMemosAndEvents.Text += "Month: " + lst[1] + "\n";
                    selectedDateMemosAndEvents.Text += "Year: " + lst[2] + "\n";
                    selectedDateMemosAndEvents.Text += "Description: " + lst[4] + "\n\n";
                }
            }
            if (selectedDateMemosAndEvents.Text == "")
            {
                selectedDateMemosAndEvents.Text = "There are no events or memos for the selected date.";
            }
        }

        //private void calenderpCalendarView_OnCalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        //{
        //    CalendarViewDayItem localItem = args.Item;
        //    if (localItem == null || args.InRecycleQueue || localItem.DataContext != null) return;

        //    //localItem.DataContext = sender.;
        //}

        private void calenderpCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            foreach (DateTimeOffset date in sender.SelectedDates)
            {
                string currentSubmittedDate = date.ToString();
                setSelectedDate(currentSubmittedDate);
                userSubmittedDate = date.ToString();
                setDatePicker();
            }
            generateDateSelectedTextBlocks();
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            //Save State
            this.Frame.Navigate(typeof(AboutPage));
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            string memos = JsonConvert.SerializeObject(memoList);
            string events = JsonConvert.SerializeObject(eventList);

            List <string> input = new List<string>();

            input.Add(memos);
            input.Add(events);

            string str = JsonConvert.SerializeObject(input);

            this.Frame.Navigate(typeof(ShowMemosAndEvents), str);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Restore state
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("data"))
            {
                string res = ApplicationData.Current.LocalSettings.Values["data"] as string;

                List<string> restoredData = JsonConvert.DeserializeObject<List<string>>(res);

                memoList = JsonConvert.DeserializeObject<List<CalendarMemo>>(restoredData[0]);
                eventList = JsonConvert.DeserializeObject<List<CalendarEvent>>(restoredData[1]);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Save state in case app is terminated later
            string memos = JsonConvert.SerializeObject(memoList);
            string events = JsonConvert.SerializeObject(eventList);

            List<string> input = new List<string>();

            input.Add(memos);
            input.Add(events);

            string str = JsonConvert.SerializeObject(input);
            ApplicationData.Current.LocalSettings.Values["data"] = str;
        }
    }
}
