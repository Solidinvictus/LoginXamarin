using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparePro.ViewModels
{
    class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public CompareViewModel Compare
        {
            get;
            set;
        }

        public RegisterViewModel Register
        {
            get;
            set;
        }

        public PreferencesViewModel Preference
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        //Para poder tener una sola instancia en toda la applicacion de la MainViewModel
        #endregion
        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion


    }
}
