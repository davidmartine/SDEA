using SDEAXamarin.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDEAXamarin.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarIncidentes : ContentPage
    {
        public MostrarIncidentes()
        {
            InitializeComponent();
            _ = this.mostrar_operador();
        }

        private async Task mostrar_operador()
        {
            VMOperador operador = new VMOperador();
            var datos = await operador.mostrar_operador();
            listaoperador.ItemsSource = datos;
        }
    }
}