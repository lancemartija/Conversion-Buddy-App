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
    public partial class BMI : ContentPage
    {
        private double RESULT;
        public BMI()
        {
            InitializeComponent();
        }

        private void Compute_BMI(object sender, EventArgs e)
        {
            if ((double.TryParse(WeightEntry.Text, out double weight)) && (double.TryParse(HeightEntry.Text, out double height)))
            {
                RESULT = Math.Round(weight / Math.Pow(height / 100.0, 2), 4);
                BMILabel.Text = RESULT + "";


                if (RESULT < 18.5)
                {
                    BMIClassLabel.Text = "Underweight";
                    BMILabel.TextColor = Color.FromHex("#555b6e");
                    BMIClassLabel.TextColor = Color.FromHex("#555b6e");
                }
                else if (RESULT < 25)
                {
                    BMIClassLabel.Text = "Healthy";
                    BMILabel.TextColor = Color.FromHex("#38b000");
                    BMIClassLabel.TextColor = Color.FromHex("#38b000");
                }
                else if (RESULT < 30)
                {
                    BMIClassLabel.Text = "Overweight";
                    BMILabel.TextColor = Color.FromHex("#fe6d73");
                    BMIClassLabel.TextColor = Color.FromHex("#fe6d73");
                }
                else if (RESULT >= 30)
                {
                    BMIClassLabel.Text = "Obese";
                    BMILabel.TextColor = Color.FromHex("#c1121f");
                    BMIClassLabel.TextColor = Color.FromHex("#c1121f");
                }
            }
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}