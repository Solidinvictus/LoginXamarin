﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComparePro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesPage : ContentPage
    {
        int index = 1;
        public PreferencesPage()
        {
            InitializeComponent();
        }

        public void changeColor(object sender, EventArgs e)
        {
           

            switch (index)
            {
                case 1:
                    BackgroundColor = Color.FromHex("#801515");
                    index++;
                    break;
                case 2:
                    BackgroundColor = Color.FromHex("#AA6C39");
                    index++;
                    break;
                case 3:
                    BackgroundColor = Color.FromHex("#AAA939");
                    index++;
                    break;
                case 4:
                    BackgroundColor = Color.FromHex("#669933");
                    index = 1;
                    break;
            }
        }
    }
}