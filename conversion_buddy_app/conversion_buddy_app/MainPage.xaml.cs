using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace conversion_buddy_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CurrencyConverter(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CurrencyConverter());
        }

        private async void FrequencyConverter(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FrequencyConverter());
        }

        private async void TemperatureConverter(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TemperatureConverter());
        }

        private async void BMI(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BMI());
        }

        private async void WeightConverter(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WeightConverter());
        }

        private async void LengthConverter(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LengthConverter());
        }

        private async void Notes(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Notes());
        }

        private async void About(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new About());
        }
    }
}
