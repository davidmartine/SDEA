using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace SDEAXamarin.Servicio
{
    public class CADMFirebase
    {
        public static FirebaseClient firebase =
                      new FirebaseClient("https://prueba-de-bd-75938-default-rtdb.firebaseio.com/Operador");
    }
}
