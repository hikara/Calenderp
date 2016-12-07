﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Calenderp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowMemosAndEvents : Page
    {
        private List<CalendarMemo> memoList;
        private List<CalendarEvent> eventList;

        public ShowMemosAndEvents()
        {
            this.InitializeComponent();

            memoList = new List<CalendarMemo>();
            eventList = new List<CalendarEvent>();
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage));
        }

        private void calendarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            List<string> outputObject = JsonConvert.DeserializeObject<List<string>>(args.Parameter as string);
            memoList = JsonConvert.DeserializeObject<List<CalendarMemo>>(outputObject[0]);
            eventList = JsonConvert.DeserializeObject<List<CalendarEvent>>(outputObject[1]);
            generateDateSelectedTextBlocks();
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
            AllMemos.Text = "";
            AllEvents.Text = "";

            foreach (List<string> lst in info)
            {
                AllEvents.Text += "Title: " + lst[3] + "\n";
                AllEvents.Text += "Day: " + lst[0] + "\n";
                AllEvents.Text += "Month: " + lst[1] + "\n";
                AllEvents.Text += "Year: " + lst[2] + "\n";
                AllEvents.Text += "Time: " + lst[4] + "\n\n";
            }
            info = generateDateSelectedStringsMemos();
            foreach (List<string> lst in info)
            {
                AllMemos.Text += "Title: " + lst[3] + "\n";
                AllMemos.Text += "Day: " + lst[0] + "\n";
                AllMemos.Text += "Month: " + lst[1] + "\n";
                AllMemos.Text += "Year: " + lst[2] + "\n";
                AllMemos.Text += "Description: " + lst[4] + "\n\n";
            }
            if (AllMemos.Text == "")
            {
                AllMemos.Text = "You have no memos.";
            }

            if (AllEvents.Text == "")
            {
                AllEvents.Text = "You have no events.";
            }
        }
    }
}
