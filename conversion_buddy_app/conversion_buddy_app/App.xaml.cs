using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conversion_buddy_app
{
    public partial class App : Application
    {
        string DbPath => FileAccessHelper.GetLocalFilePath("list.db3");

        public static NotesRepository NotesRepo { get; private set; }

        public App()
        {
            InitializeComponent();

            NotesRepo = new NotesRepository(DbPath);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
