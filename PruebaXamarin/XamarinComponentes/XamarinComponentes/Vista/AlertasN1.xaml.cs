using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinComponentes.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertasN1 : PopupPage
    {
        public AlertasN1()
        {
            InitializeComponent();
        }

        private void Validar_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}