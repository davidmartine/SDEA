using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinComponentes.Modelo;

namespace XamarinComponentes.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        public IList<MComidas> comidas { get; private set; }
        public MenuPrincipal()
        {
            InitializeComponent();
            comidas= new List<MComidas>();
            comidas.Add(new MComidas
            {
                Nombre="Registro Cita",
                Precio= "aplicacionmovil.png"
            });
            comidas.Add(new MComidas
            {
                Nombre="Consultas",
                Precio= "usuario.png"
            });
            comidas.Add(new MComidas
            {
                Nombre="Fechas",
                Precio= "medicina.png"
            });
            comidas.Add(new MComidas
            {
                Nombre="Operador",
                Precio= "servicioalcliente.png"
            });


            BindingContext = this;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MComidas comidas = e.Item as MComidas;
            if (comidas.Nombre.Equals("Registro Cita"))
            {
                Navigation.PushAsync(new Tarjetas());
            }
            if (comidas.Nombre.Equals("Consultas"))
            {
                Navigation.PushAsync(new Alertas());
            }
            if (comidas.Nombre.Equals("Fechas"))
            {
                Navigation.PushAsync(new FechaHora());
            }
            if (comidas.Nombre.Equals("Operador"))
            {
                Navigation.PushAsync(new Operador());
            }

        }
    }
}