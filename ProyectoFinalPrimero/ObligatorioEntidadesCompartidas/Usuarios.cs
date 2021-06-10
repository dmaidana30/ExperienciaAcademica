using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioEntidadesCompartidas
{
    public class Usuarios
    {
        #region Atributos
        string usuarioLogueo;
        string clave;
        string nombreCompleto;
        #endregion

        #region Propiedades

        public string UsuarioLogueo
        {
            get { return usuarioLogueo; }
            set
            {
                if (value.Trim().Length > 20)
                    throw new Exception("La extensión del usuario debe ser menor o igual a 20.");
                else if (value.Trim() == "")
                    throw new Exception("El usuario de logueo no puede estar vacío.");
                else
                usuarioLogueo = value;
            }
        }
        public string Clave
        {
            get { return clave; }
            set
            {
                if (value.Trim().Length > 20)
                    throw new Exception("La extensión de la clave debe ser menor o igual a 20.");
                else if (value.Trim() == "")
                    throw new Exception("La clave de logueo no puede estar vacío.");
                else
                clave = value;
            }
        }
        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set
            {
                if (value.Trim().Length > 50)
                    throw new Exception("La extensión del nombre completo debe ser menor o igual a 20.");
                else if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacío.");
                else
                nombreCompleto = value;
            }
        }

        #endregion

        #region Constructor

        public Usuarios(string pUsuarioLogueo, string pClave, string pNombreComplero)
        {
            UsuarioLogueo = pUsuarioLogueo;
            Clave = pClave;
            NombreCompleto = pNombreComplero;
        }


        #endregion

        #region Operaciones
        #endregion
    }
}
