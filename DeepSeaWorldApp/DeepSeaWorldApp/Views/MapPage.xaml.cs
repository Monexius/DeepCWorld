using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DeepSeaWorldApp.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        public MapPage(string eventName)
        {
            InitializeComponent();
            label.Text = eventName;
            //get location associated with eventName
            //display different image depending on location, displaying map with that location highlighted
                //using switch case?
        }
    }
}
