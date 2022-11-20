using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using SDEAXamarin.Model;
using SDEAXamarin.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SDEAXamarin.VistaModelo
{
    public class VMRegistro : MBaseRegistro
    {
        public string email;
        public string password;
        public string name;
        public string age;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;

        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public string NameTxt
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string AgeTxt
        {
            get { return this.age; }
            set{ SetValue(ref this.age, value);}
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set {SetValue(ref this.isVisible, value);}
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value);}
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public ICommand RegisterCommand
        {
            get { return new RelayCommand(RegisterMethod); }
        }

        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo Email esta vacio",
                    "OK");
                return;
            }

            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo Password esta vacio",
                    "OK");
                return;
            }

            string WebApiKey = "AIzaSyCuM1IG7JukRceavV5DHGpYc72G4vBepEg";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
                string gettoken = auth.FirebaseToken;

                await Application.Current.MainPage.Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }

        public VMRegistro()
        {
            IsEnabledTxt = true;
        }
    }
}
