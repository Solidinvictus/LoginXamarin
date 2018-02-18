using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ComparePro.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    //using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    class LoginViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;       //Esta interfaz es para refrescar 
        #endregion

        //Los atributos privados que necesitamos refrescar
        #region Atributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private bool isRemembered;
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if(this.password != value)
                {
                    this.password = value;
                    //Para refrescar las instrucciones en tpo de ejecucion
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(this.Password)));
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                if (this.isRunning != value)
                {
                    this.isRunning = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }
            }
        }

        public bool IsRemembered
        {
            get
            {
                return this.isRemembered;
            }
            set
            {
                if (this.isRemembered != value)
                {
                    this.isRemembered = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(this.IsRemembered)));
                }
            }
        }

        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);     //De la libreria instalada GalaSoft.MvvmLight.Command, y le pasamos un metodo por param
            }
        }

        //Param del RelayCommand
        private async void Login()      //Para manejar los alerts en dif dispos, hace falta metodos asincronos
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",        //Titulo del error
                    "You must enter an email ",     //Mensaje del error
                    "Accept");      //Texto del boton
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password ",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;
            //Esto es temporal, ya que esto debería ir a un archivo de recursos (solucion temporal) y luego en la BBDD
            if (this.Email != "welltec@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Email or password incorrect ",
                   "Accept");
                //Limpiamos el campo del password al ingresar uno erroneo
                this.Password = string.Empty;       //No va a funcionar pq no está referenciado en el ViewModel-->sol: Implementar la interfaz INotifyPropertyChanged
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
                "Ok",
                "Hell Yeah!!",
                "Accept");
            return;
        }

        public ICommand RegisterCommand
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion  
    }
}
