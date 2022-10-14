using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinComponentes.Modelo;
using XamarinComponentes.VistaModelo;


namespace XamarinComponentes.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Operador : ContentPage
    {
        public Operador()
        {
            InitializeComponent();
            _ = this.mostar_operador();
        }
        

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
           await insertar_operador();
        }
        MediaFile file;
        private async Task insertar_operador()
        {
            VMOperador operador = new VMOperador();
            MOperador parametros = new MOperador();

            parametros.Accion = txtAccion.Text;
            parametros.Cedula = txtCedula.Text;
            parametros.Descripcion = txtDescripcion.Text;
            parametros.Edad = txtEdad.Text;
            parametros.Eps = txtEps.Text;
            parametros.Evento = txtEvento.Text;
            parametros.FechaNacimiento = txtFechaNacimiento.Text;
            parametros.Nombre = txtNombre.Text;
            parametros.Telefono = txtTelefono.Text;

            await operador.insertar_operador(parametros);
            await DisplayAlert("Listo", "Operador pruega agregado", "OK");
            await mostar_operador();
        }

        private async Task mostar_operador()
        {
            VMOperador operador = new VMOperador();
            var datos = await operador.mostrar_operador();
            listaoperador.ItemsSource = datos;

        }
        
        private async void btnAgregarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                var files = await CrossMedia.Current.PickPhotosAsync(new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                }) ;
                if(files == null)
                    return;
                    ImagenOp.Source = ImageSource.FromStream(() =>
                    {
                        var rutaimagen = file.GetStream();
                        return rutaimagen;
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}