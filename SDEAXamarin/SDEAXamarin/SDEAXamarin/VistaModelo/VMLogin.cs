using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using SDEAXamarin.Model;
using SDEAXamarin.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SDEAXamarin.VistaModelo
{
    public class VMLogin : MBaseRegistro
    {
        public string email;
        public string password;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;

        public string EmailTxt
        {
            get { return email; }
            set { SetValue(ref this.email, value); }
        }
        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue (ref this.password, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled,value); }
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Loggin); }
        }

        public async void Loggin()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo emial se encuentra vacio",
                    "OK");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo password se encuentra vacio",
                    "OK");
                return;
            }

            string WebApiKey = "AIzaSyCuM1IG7JukRceavV5DHGpYc72G4vBepEg";

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
                var content = await auth.GetFreshAuthAsync();
                var serialzedcontnet = JsonConvert.SerializeObject(content);

                Preferences.Set("MyFirebaseRefreshToken", serialzedcontnet);
                await App.Current.MainPage.DisplayAlert("Exito", "Login Correcto", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new MenuOperador());
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error al momento de iniciar sesion", "OK");
            }
            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);

            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;
        }

        public async void ResetPasswordEmail()
        {
            string WebApiKey = "AIzaSyCuM1IG7JukRceavV5DHGpYc72G4vBepEg";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                await authProvider.SendEmailVerificationAsync(email);
            }
            catch(Exception ex)
            {

            }
        }

        public VMLogin()
        {
            this.IsEnabledTxt = true;
        }


    }
}
