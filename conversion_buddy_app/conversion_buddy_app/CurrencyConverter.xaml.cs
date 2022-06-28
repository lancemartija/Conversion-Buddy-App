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
    public partial class CurrencyConverter : ContentPage
    {
        private const double USD = 53.335;
        private const double GBP = 64.4412;
        private const double JPY = 0.3966;
        private const double SAR = 14.2374;
        private const double AED = 14.5433;
        public double RESULT;

        public CurrencyConverter()
        {
            InitializeComponent();
        }

        private double Convert_ForeignValueToPeso(double foreignValue, double amount)
        {
            return foreignValue * amount;
        }

        private void SelectedCurrency(string currency, double amount)
        {
            if (currency == "US Dollar (USD)")
                RESULT = Convert_ForeignValueToPeso(USD, amount);
            else if (currency == "British Pound (GBP)")
                RESULT = Convert_ForeignValueToPeso(GBP, amount);
            else if (currency == "Japanese Yen (JPY)")
                RESULT = Convert_ForeignValueToPeso(JPY, amount);
            else if (currency == "Saudi Riyal (SAR)")
                RESULT = Convert_ForeignValueToPeso(SAR, amount);
            else if (currency == "UAE Dirham (AED)")
                RESULT = Convert_ForeignValueToPeso(AED, amount);
        }

        private void Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currency = (string)Currency.SelectedItem;

            if (string.IsNullOrEmpty(currency) ||
                string.IsNullOrEmpty(ForeignValue.Text))
                return;

            if (!double.TryParse(ForeignValue.Text, out double amount))
                return;

            SelectedCurrency(currency, amount);
            Peso.Text = "₱ " + RESULT;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currency = (string)Currency.SelectedItem;

            if (string.IsNullOrEmpty(currency) ||
                string.IsNullOrEmpty(ForeignValue.Text) ||
                ForeignValue.Text == ".")
            {
                Peso.Text = "₱ 0";
                return;
            }

            if (!double.TryParse(ForeignValue.Text, out double amount))
                return;

            SelectedCurrency(currency, amount);
            Peso.Text = "₱ " + RESULT;
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}