using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ComparePro
{
    using Xamarin.Forms;
    using Views;
    //Empezemos!
    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());     //Arrancamos la app de momento desde el login
           
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
