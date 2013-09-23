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
    public partial class HighScorePage : PhoneApplicationPage
    {
        public HighScorePage()
        {
            InitializeComponent();
            yourHighScoreBlock.Text = App.GetLocalHighScore().ToString();
            globalHighScoreBlock.Text = App.GlobalHighScoresList[0].Score.ToString(); 
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }   
    }
}