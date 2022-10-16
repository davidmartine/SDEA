using SDEAXamarin.Model;
using SDEAXamarin.VistaModelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDEAXamarin.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresarInsidente : ContentPage
    {
        public IngresarInsidente()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
          await insertar_operador();
        }


        
        private async Task insertar_operador()
        {
            try
            {
                //var fechaactual = DateTime.Now;
                //var fecha_nacimiento = Convert.ToDateTime(dpFechaNacimiento.Date);
                //string edad_calculada = (fechaactual - fecha_nacimiento).ToString();
                //txtEdad.Text = edad_calculada;
                VMOperador operador = new VMOperador();
                MOperador parametros = new MOperador();

                parametros.Accion = txtAccion.Text;
                parametros.Cedula=txtCedula.Text;
                parametros.Descripcion = txtDescripcion.Text;
                parametros.Edad=txtEdad.Text;
                parametros.Eps = pEps.SelectedItem.ToString();
                parametros.Evento=txtEvento.Text;
                parametros.FechaNacimiento = dpFechaNacimiento.Date.ToString();
                parametros.Nombre = txtNombre.Text;
                parametros.Telefono = txtTelefono.Text;

                await operador.insertar_operador(parametros);
                await DisplayAlert("REPORTE DE INCIDENTE", "Registro Guardado Satisfactoriamente", "OK");
                txtAccion.Text = "";
                txtCedula.Text="";
                txtDescripcion.Text="";
                pEps.SelectedIndex=0;
                txtEvento.Text="";
                txtNombre.Text="";
                txtTelefono.Text = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
               
            }
            


        }

    }
}