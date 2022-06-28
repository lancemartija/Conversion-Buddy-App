using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conversion_buddy_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemperatureConverter : ContentPage
    {

        public TemperatureConverter()
        {
            InitializeComponent();
        }

        private double Convert_CelsiusToFahrenheit(double value)
        {
            return Math.Round((value * 9) / 5 + 32, 4);
        }

        private double Convert_CelsiusToKelvin(double value)
        {
            return Math.Round(value + 273.15, 4);
        }

        private double Convert_FahrenheitToCelsius(double value)
        {
            return Math.Round((value - 32) * 5 / 9, 4);
        }

        private double Convert_FahrenheitToKelvin(double value)
        {
            return Math.Round((value - 32) * 5 / 9 + 273.15, 4);
        }

        private double Convert_KelvinToCelsius(double value)
        {
            return Math.Round(value - 273.15, 4);
        }

        private double Convert_KelvinToFahrenheit(double value)
        {
            return Math.Round((value - 273.15) * (9 / 5) + 32, 4);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;

            if (string.IsNullOrEmpty(entry.Text))
            {
                CelsiusEntry.Text = "";
                FahrenheitEntry.Text = "";
                KelvinEntry.Text = "";
                return;
            }

            if (!double.TryParse(entry.Text, out double value))
                return;

            if (entry == CelsiusEntry && CelsiusEntry.IsFocused)
            {
                FahrenheitEntry.Text = Convert_CelsiusToFahrenheit(value) + "";
                KelvinEntry.Text = Convert_CelsiusToKelvin(value) + "";
            }
            else if (entry == FahrenheitEntry && FahrenheitEntry.IsFocused)
            {
                CelsiusEntry.Text = Convert_FahrenheitToCelsius(value) + "";
                KelvinEntry.Text = Convert_FahrenheitToKelvin(value) + "";
            } 
            else if (entry == KelvinEntry && KelvinEntry.IsFocused)
            {
                CelsiusEntry.Text = Convert_KelvinToCelsius(value) + "";
                FahrenheitEntry.Text = Convert_KelvinToFahrenheit(value) + "";
            }
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}