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
    public partial class WeightConverter : ContentPage
    {
        private const double WEIGHT_UNIT = 2.2;

        public WeightConverter()
        {
            InitializeComponent();
        }

        private double Convert_KGToLB(double value)
        {
            return Math.Round(value / WEIGHT_UNIT, 4);
        }

        private double Convert_LBToKG(double value)
        {
            return Math.Round(value * WEIGHT_UNIT, 4);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;

            if (string.IsNullOrEmpty(entry.Text))
            {
                KilogramEntry.Text = "";
                PoundEntry.Text = "";
                return;
            }

            if (!double.TryParse(entry.Text, out double value))
                return;

            if (entry == KilogramEntry && KilogramEntry.IsFocused)
                PoundEntry.Text = Convert_KGToLB(value) + "";
            else if (entry == PoundEntry && PoundEntry.IsFocused)
                KilogramEntry.Text = Convert_LBToKG(value) + "";
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}