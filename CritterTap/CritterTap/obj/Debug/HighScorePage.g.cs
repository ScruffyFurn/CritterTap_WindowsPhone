﻿#pragma checksum "C:\GitHub\CritterTap_Phone_XAML\CritterTap\CritterTap\HighScorePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6175C0618A51094DA61012CDFA3C3723"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace CritterTap {
    
    
    public partial class HighScorePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button backButton;
        
        internal System.Windows.Controls.TextBlock globalHighScoreBlock;
        
        internal System.Windows.Controls.TextBlock yourHighScoreBlock;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/CritterTap;component/HighScorePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.backButton = ((System.Windows.Controls.Button)(this.FindName("backButton")));
            this.globalHighScoreBlock = ((System.Windows.Controls.TextBlock)(this.FindName("globalHighScoreBlock")));
            this.yourHighScoreBlock = ((System.Windows.Controls.TextBlock)(this.FindName("yourHighScoreBlock")));
        }
    }
}

