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
        public int selectedYear = Int32.MaxValue;
        public int selectedMonth = Int32.MaxValue;
        public int selectedDay = Int32.MaxValue;

        public MainPage()
        {
            this.InitializeComponent();
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-US");
            setSelectedDate(localDate.ToString(culture));
        }

        private void AddMemoOrEvent_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SetMemoOrEvent));
        }

        private void addCalendarPicker(string headerType, int year, int month, int day)
        {
            CalendarDatePicker arrivalCalendarDatePicker = new CalendarDatePicker();
            arrivalCalendarDatePicker.Header = headerType + " date";
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
            titleLabel.Margin = new Thickness(5, 55, 5, 5);
            addMemoEventGrid.Children.Add(titleLabel);
        }

        private void addUserGivenTitle(string titleType)
        {
            TextBox userGivenTitle = new TextBox();
            userGivenTitle.Text = "Enter A Title For Your " + titleType;
            userGivenTitle.HorizontalAlignment = HorizontalAlignment.Right;
            userGivenTitle.VerticalAlignment = VerticalAlignment.Top;
            userGivenTitle.Height = 30;
            userGivenTitle.Width = 475;
            userGivenTitle.Margin = new Thickness(5, 55, 5, 5);
            userGivenTitle.Background = new SolidColorBrush(Color.FromArgb(255, 48, 179, 221));
            addMemoEventGrid.Children.Add(userGivenTitle);
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
            descriptionLabel.Margin = new Thickness(5, 105, 5, 5);
            addMemoEventGrid.Children.Add(descriptionLabel);
        }

        private void addUserGivenMemo()
        {
            TextBox userGivenMemo = new TextBox();
            userGivenMemo.Text = "Memo";
            userGivenMemo.HorizontalAlignment = HorizontalAlignment.Right;
            userGivenMemo.VerticalAlignment = VerticalAlignment.Top;
            userGivenMemo.Height = 500;
            userGivenMemo.Width = 475;
            userGivenMemo.Margin = new Thickness(5, 105, 5, 5);
            userGivenMemo.Background = new SolidColorBrush(Color.FromArgb(255, 48, 179, 221));
            addMemoEventGrid.Children.Add(userGivenMemo);
        }

        private void addMemo_Click(object sender, RoutedEventArgs e)
        {
            int count = addMemoEventGrid.Children.Count();
            for (int i = 0; i < count; i++)
            {
                addMemoEventGrid.Children.RemoveAt(0);
            }

            addTitle("Memo Title:");
            addUserGivenTitle("Memo");
            addDescriptionlabel();
            addUserGivenMemo();
        }

        private void addEvent_Click(object sender, RoutedEventArgs e)
        {
            int count = addMemoEventGrid.Children.Count();
            for (int i = 0; i < count; i++)
            {
                addMemoEventGrid.Children.RemoveAt(0);
            }

            addTitle("Event Title:");
            addUserGivenTitle("Event");
        }

        private void calenderpCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            IList<DateTimeOffset> dates = calenderpCalendarView.SelectedDates;
            foreach (DateTimeOffset date in dates)
            {
                string selectedDate = date.ToString();
                setSelectedDate(selectedDate);
            }
        }
    }
}
