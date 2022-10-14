using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinComponentes.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alertas : ContentPage
    {
        public Alertas()
        {
            InitializeComponent();
        }

        private void btnAlerta_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new AlertasN1());
        }
    }
}