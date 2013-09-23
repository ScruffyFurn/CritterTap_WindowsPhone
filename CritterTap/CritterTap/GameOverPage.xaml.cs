using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CritterTap
{
    public partial class GameOverPage : PhoneApplicationPage
    {
        public GameOverPage()
        {
            InitializeComponent();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HighScorePage.xaml", UriKind.Relative));
        }
    }
}