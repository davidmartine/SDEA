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
            if (!string.IsNullOrEmpty(txtNumerouno.Text))
            {
                if (!string.IsNullOrEmpty(txtNumero2.Text))
                {
                    numero1 = Convert.ToDouble(txtNumerouno.Text);
                    numero2 = Convert.ToDouble(txtNumero2.Text);
                    resultado = numero1 * numero2;
                    DisplayAlert("Resultado Calculado", resultado.ToString(), "OK");
                }
                else
                {
                    DisplayAlert("Error", "No es posible realizar ejecucion", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "No es posible realizar ejecucion", "OK");
            }
        }

        private void Logo_Clicked(object sender, EventArgs e)
        {
            //pasar de pagina -->PushAsync para ir 
            Navigation.PushAsync(new PrimeraPag());
        }
    }
}
