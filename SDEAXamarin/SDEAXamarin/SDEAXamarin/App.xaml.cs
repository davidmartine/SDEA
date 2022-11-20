﻿using SDEAXamarin.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDEAXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Registro());
            //MainPage = new NavigationPage(new MenuOperador());
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
