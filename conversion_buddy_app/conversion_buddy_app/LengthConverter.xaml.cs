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
    public partial class LengthConverter : ContentPage
    {
        private const double LENGTH_UNIT = 30.48;
        public LengthConverter()
        {
            InitializeComponent();
        }

        private double Convert_CMToFT(double value)
        {
            return Math.Round(value / LENGTH_UNIT, 4);
        }

        private double Convert_FTToCM(double value)
        {
            return Math.Round(value * LENGTH_UNIT, 4);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;

            if (string.IsNullOrEmpty(entry.Text))
            {
                FootEntry.Text = "";
                CentimeterEntry.Text = "";
                return;
            }

            if (!double.TryParse(entry.Text, out double value))
                return;

            if (entry == FootEntry && FootEntry.IsFocused)
                CentimeterEntry.Text = Convert_FTToCM(value) + "";
            else if (entry == CentimeterEntry && CentimeterEntry.IsFocused)
                FootEntry.Text = Convert_CMToFT(value) + "";
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}