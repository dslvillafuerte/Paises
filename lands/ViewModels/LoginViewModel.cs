using System;


namespace lands.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using lands.Views;
    using Xamarin.Forms;

    public class LoginViewModel:BaseViewModel  
    {
       

        #region Attributes
        private string userName;
        private string pin;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string UserName
        {
            get { return this.userName; }
            set { SetValue(ref this.userName, value); }

        }

        public string Pin
        {
            get { return this.pin; }
            set { SetValue(ref this.pin, value); }

        }

        public bool IsRemember
        {
            get;
            set;

        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }

        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }


        #endregion

        #region Commands

        public ICommand LoggingCommand
        {
            get
            {
                return new RelayCommand(Logging);
            }
           
        }



        private async void Logging()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                await Application.Current.MainPage.DisplayAlert("Bienvenido", "Por favor, debes escribir tu usuario", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(Pin))
            {
                await Application.Current.MainPage.DisplayAlert("Bienvenido", "Por favor, debes escribir tu PIN", "Accept");
                return;

            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Pin != "1234")
            {
                
                await Application.Current.MainPage.DisplayAlert("Bienvenido", "No se reconoce el usuario y PIN", "Accept");
                this.Pin = string.Empty;
                return;
            }

            MainViewModel.GetInstance().Lands = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());


            this.UserName = string.Empty;
            this.Pin = string.Empty;




            this.IsRunning = false;
            this.IsEnabled = true;

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
            this.IsRunning = false;
            this.IsRemember = true;
            this.IsEnabled = true;
            this.UserName = "luis";
        }
        #endregion

    }
}
