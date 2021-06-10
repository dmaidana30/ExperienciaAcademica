using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using ObligatorioDatos;

namespace ObligatorioLogica
{
    public class LogicaUsuarios
    {

        public static Usuarios Buscar(string pUsuario)
        {
            Usuarios pUsu = DatosUsuarios.BuscarUsuario(pUsuario);
            return pUsu;
        }
        public static Usuarios Logueo(string pUsu, string pPass)
        {
            Usuarios unUsu = null;
            unUsu = DatosUsuarios.Logueo(pUsu, pPass);
            return unUsu;
        }
        
            public static void AgregarUsuarios(Usuarios pUsu)
            {
                DatosUsuarios.AgregarUsuarios(pUsu);
            }
           
            public static void ModificarUsuarios(Usuarios pUsu)
            {
                DatosUsuarios.ModificarUsuarios(pUsu);
            }
            
        public static void EliminarUsuarios(Usuarios Clas)
            {
                DatosUsuarios.EliminarUsuarios(Clas);
            }
           
        }
}
