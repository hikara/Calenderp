﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calenderp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddMemoOrEvent_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SetMemoOrEvent));
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
            titleLabel.Margin = new Thickness(5, 5, 5, 5);
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
            descriptionLabel.Margin = new Thickness(5, 55, 5, 5);
            addMemoEventGrid.Children.Add(descriptionLabel);
        }

        private void addUserGivenMemo()
        {
            TextBox userGivenMemo = new TextBox();
            userGivenMemo.Text = "Memo";
            userGivenMemo.HorizontalAlignment = HorizontalAlignment.Right;
            userGivenMemo.VerticalAlignment = VerticalAlignment.Top;
            userGivenMemo.Height = 600;
            userGivenMemo.Width = 475;
            userGivenMemo.Margin = new Thickness(5, 55, 5, 5);
            userGivenMemo.Background = new SolidColorBrush(Color.FromArgb(255, 48, 179, 221));
            addMemoEventGrid.Children.Add(userGivenMemo);
        }

        private void addMemo_Click(object sender, RoutedEventArgs e)
        {
            //addMemoEventGrid = new Grid();
            //addMemoEventGrid.Background = new SolidColorBrush(Color.FromArgb(255, 85, 127, 125));
            //addMemoEventGrid.Margin = new Thickness(75, 182, 1185, 147);
            //addMemoEventGrid.Name = "addMemoEventGrid";
            addTitle("Memo Title:");
            addUserGivenTitle("Memo");
            addDescriptionlabel();
            addUserGivenMemo();
        }

        private void addEvent_Click(object sender, RoutedEventArgs e)
        {
            addTitle("Event Title:");
            addUserGivenTitle("Event");
        }
    }
}
