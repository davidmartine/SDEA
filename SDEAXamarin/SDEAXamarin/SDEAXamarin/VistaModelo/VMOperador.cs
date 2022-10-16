using Firebase.Database.Query;
using SDEAXamarin.Model;
using SDEAXamarin.Servicio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SDEAXamarin.VistaModelo
{
    public class VMOperador
    {
        public async Task insertar_operador(MOperador operador)
        {
            try
            {
                var data = await CADMFirebase.firebase
                                .Child("Operador")
                                .PostAsync(new MOperador()
                                {
                                    Accion = operador.Accion,
                                    Cedula = operador.Cedula,
                                    Descripcion = operador.Descripcion,
                                    Edad = operador.Edad,
                                    Eps = operador.Eps,
                                    Evento = operador.Evento,
                                    FechaNacimiento = operador.FechaNacimiento,
                                    Nombre = operador.Nombre,
                                    Telefono = operador.Telefono
                                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


        }
    }
}
