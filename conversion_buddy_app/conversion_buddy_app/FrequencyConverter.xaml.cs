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
    public partial class FrequencyConverter : ContentPage
    {

        public FrequencyConverter()
        {
            InitializeComponent();
        }

        private double Convert_HzTokHz(double value)
        {
            return value / 0.001;
        }

        private double Convert_HzToMHz(double value)
        {
            return value / 1000000;
        }

        private double Convert_HzToGHz(double value)
        {
            return value / 1000000000;
        }

        private double Convert_kHzToHz(double value)
        {
            return value * 1000;
        }

        private double Convert_kHzToMHz(double value)
        {
            return value / 1000;
        }

        private double Convert_kHzToGHz(double value)
        {
            return value / 1000000;
        }

        private double Convert_MHzToHz(double value)
        {
            return value * 1000000;
        }

        private double Convert_MHzTokHz(double value)
        {
            return value * 1000;
        }

        private double Convert_MHzToGHz(double value)
        {
            return value / 1000;
        }

        private double Convert_GHzToHz(double value)
        {
            return value * 1000000000;
        }

        private double Convert_GHzTokHz(double value)
        {
            return value * 1000000;
        }

        private double Convert_GHzToMHz(double value)
        {
            return value * 1000;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;

            if (string.IsNullOrEmpty(entry.Text))
            {
                HertzEntry.Text = "";
                KilohertzEntry.Text = "";
                MegahertzEntry.Text = "";
                GigahertzEntry.Text = "";
                return;
            }

            if (!double.TryParse(entry.Text, out double value))
                return;

            if (entry == HertzEntry && HertzEntry.IsFocused)
            {
                KilohertzEntry.Text = Convert_HzTokHz(value) + "";
                MegahertzEntry.Text = Convert_HzToMHz(value) + "";
                GigahertzEntry.Text = Convert_HzToGHz(value) + "";
            }
            else if (entry == KilohertzEntry && KilohertzEntry.IsFocused)
            {
                HertzEntry.Text = Convert_kHzToHz(value) + "";
                MegahertzEntry.Text = Convert_kHzToMHz(value) + "";
                GigahertzEntry.Text = Convert_kHzToGHz(value) + "";
            }
            else if (entry == MegahertzEntry && MegahertzEntry.IsFocused)
            {
                HertzEntry.Text = Convert_MHzToHz(value) + "";
                KilohertzEntry.Text = Convert_MHzTokHz(value) + "";
                GigahertzEntry.Text = Convert_MHzToGHz(value) + "";
            }
            else if (entry == GigahertzEntry && GigahertzEntry.IsFocused)
            {
                HertzEntry.Text = Convert_GHzToHz(value) + "";
                KilohertzEntry.Text = Convert_GHzTokHz(value) + "";
                MegahertzEntry.Text = Convert_GHzToMHz(value) + "";
            }
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}