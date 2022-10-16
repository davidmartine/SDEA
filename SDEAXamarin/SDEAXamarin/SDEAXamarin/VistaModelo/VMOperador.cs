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

        List<MOperador> operadors = new List<MOperador>();

        public async Task <List<MOperador>> mostrar_operador()
        {
                var data = await CADMFirebase.firebase
                       .Child("Operador")
                       .OrderByKey()
                       .OnceAsync<MOperador>();

                foreach (var datos in data)
                {
                    MOperador parametros = new MOperador();
                    parametros.Cedula = datos.Key;
                    parametros.Accion = datos.Object.Accion;
                    parametros.Descripcion = datos.Object.Descripcion;
                    parametros.Edad = datos.Object.Edad;
                    parametros.Eps = datos.Object.Eps;
                    parametros.Evento = datos.Object.Evento;
                    parametros.FechaNacimiento = datos.Object.FechaNacimiento;
                    parametros.Nombre = datos.Object.Nombre;
                    parametros.Telefono = datos.Object.Telefono;

                    operadors.Add(parametros);
                }
                return this.operadors;
            
        }
    }
}
