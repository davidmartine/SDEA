using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaXamarin.Vista
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        double numero1;
        double numero2;
        double resultado;

        private void Pruebas_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Prueba de mensaje", "Hola Prueba", "OK");
        }

        private void btnConfig_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            calcular();
        }

        private void calcular()
        {
            numero1 =Convert.ToDouble(txtNumerouno.Text);
            numero2 = Convert.ToDouble(txtNumero2.Text);
            resultado = numero1 * numero2;
            DisplayAlert("Resultado Calculado", resultado.ToString(), "OK");
        }
    }
}
