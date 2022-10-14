using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace XamarinComponentes.Servicios
{
    public class ConexionFirebase
    {
        public static FirebaseClient firebase = 
                      new FirebaseClient("https://prueba-de-bd-75938-default-rtdb.firebaseio.com/Operador");

    }
}
