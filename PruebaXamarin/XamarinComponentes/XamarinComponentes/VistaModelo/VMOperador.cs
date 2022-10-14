using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XamarinComponentes.Modelo;
using XamarinComponentes.Servicios;

namespace XamarinComponentes.VistaModelo
{
    public class VMOperador
    {
        List<MOperador> operador = new List<MOperador>();
        public async Task <List<MOperador>> mostrar_operador()
        {
            //MOSTRAR DATOS FIREBASE....
            var data = await ConexionFirebase.firebase
                .Child("Operador")
                .OrderByKey()
                .OnceAsync<MOperador>();

            foreach(var datos in data)
            {
                MOperador parametros = new MOperador();
                parametros.Cedula = datos.Key; // OBTENIENDO EL ID
                parametros.Accion = datos.Object.Accion;
                parametros.Descripcion = datos.Object.Descripcion;
                parametros.Edad = datos.Object.Edad;
                parametros.Eps = datos.Object.Eps;
                parametros.Evento = datos.Object.Evento;
                parametros.FechaNacimiento = datos.Object.FechaNacimiento;
                parametros.Nombre = datos.Object.Nombre;
                parametros.Telefono = datos.Object.Telefono;

                operador.Add(parametros);

            }
            return operador;
        }

        public async Task insertar_operador(MOperador parametros)
        {
            var data = await ConexionFirebase.firebase
                .Child("Operador")
                .PostAsync(new MOperador()
                {
                    Accion = parametros.Accion,
                    Cedula = parametros.Cedula,
                    Descripcion = parametros.Descripcion,
                    Edad = parametros.Edad,
                    Eps = parametros.Eps,
                    Evento = parametros.Evento,
                    FechaNacimiento = parametros.FechaNacimiento,
                    Nombre = parametros.Nombre,
                    Telefono = parametros.Telefono,
                });
        }


        string rutafoto;
        public async Task<string> SubirImagenStorega(Stream imagenstream, string idoperador)
        {
            var dataAlmacenamiento = await new FirebaseStorage("prueba-de-bd-75938.appspot.com")
                .Child("Operador")
                .Child(idoperador + ".png")
                .PutAsync(imagenstream);
            rutafoto = dataAlmacenamiento;
            return rutafoto;
        }
        
    }
}
