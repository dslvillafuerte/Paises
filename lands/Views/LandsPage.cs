using System;

using Xamarin.Forms;

namespace lands.Views
{
    public class LandsPage : ContentPage
    {
        public LandsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

