using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conversion_buddy_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conversion_buddy_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notes : ContentPage
    {
        public Notes()
        {
            InitializeComponent();
            DisplayList();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.NotesRepo.AddNewNotesAsync(newNotes.Text);
            statusMessage.Text = App.NotesRepo.StatusMessage;

            DisplayList();

            newNotes.Text = "";
        }
        public async void OnDeleteButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.NotesRepo.DeleteNotesAsync(sender, args);
            statusMessage.Text = App.NotesRepo.StatusMessage;

            DisplayList();
        }

        public async void DisplayList()
        {
            statusMessage.Text = "";

            List<Items> list = await App.NotesRepo.GetAllItemsAsync();
            notesList.ItemsSource = list;
        }

        public async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}