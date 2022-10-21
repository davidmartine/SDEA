using SDEAXamarin.Model;
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

    public partial class Consultor : ContentPage
    {

        public IList<MmConsultor> consultors { get; private set; }
        public Consultor()
        {
            InitializeComponent();
            consultors = new List<MmConsultor>();
            consultors.Add(new MmConsultor()
            {
                Tipo = "CONSULTAR",
                Descripcion = "CONSULTAR INCIDENTES",
                Imagen = "registrosmedicos.png"
            });

            BindingContext = this;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MmConsultor consultor = e.Item as MmConsultor;
            if (consultor.Tipo.Equals("CONSULTAR"))
            {
                Navigation.PushAsync(new MostrarIncidentes());
            }
        }
    }
}