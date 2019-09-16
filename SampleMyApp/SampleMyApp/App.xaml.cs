using SampleMyApp.Helpers;
using SampleMyApp.Services.NavigationServices;
using SampleMyApp.Utills.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp
{
    public partial class App : Application
    {
        static App()
        {
            BuilDependencies();
        }

        private static void BuilDependencies()
        {
            Locator.Instance.Build();
        }
        public App()
        {
            InitializeComponent();
            InitNavigation();
            //MainPage = new MainPage();
        }

        private Task InitNavigation()
        {
            var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        static SQLiteHelper db;
        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper();
                }
                return db;
            }
        }
    }
}
