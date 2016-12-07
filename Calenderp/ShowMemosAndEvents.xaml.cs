using Newtonsoft.Json;
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
            // Page was navigated to
            List<string> fkdjnsljkn = JsonConvert.DeserializeObject<List<string>>(args.Parameter as string);



            memoList = JsonConvert.DeserializeObject<List<CalendarMemo>>(fkdjnsljkn[0]);
            eventList = JsonConvert.DeserializeObject<List<CalendarEvent>>(fkdjnsljkn[1]);
            var hi = 0;
        }
    }
}
