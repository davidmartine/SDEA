﻿using SDEAXamarin.Model;
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
    public partial class MenuOperador : ContentPage
    {
        public IList<MMenuOperador> operadors { get; private set; }
        public MenuOperador()
        {
            InitializeComponent();
            operadors = new List<MMenuOperador>();
            operadors.Add(new MMenuOperador()
            {
                Descripcion="REGISTRO DE INCIDENCIA",
                Imagen= "registrosmedicos.png"
            });
            operadors.Add(new MMenuOperador()
            {
                Descripcion="MOSTRAR REGISTROS",
                Imagen= "reporte.png"
            });
            BindingContext = this;
        }
        

       

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}