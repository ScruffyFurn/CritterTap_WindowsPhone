using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace CritterTap
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReadyPage.xaml", UriKind.Relative));
        }

        private void highScoreButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HighScorePage.xaml", UriKind.Relative));
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }
    }
}