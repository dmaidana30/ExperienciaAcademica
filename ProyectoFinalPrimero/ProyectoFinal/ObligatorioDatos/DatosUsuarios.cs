using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace ObligatorioDatos
{
    public class DatosUsuarios
    {
        public static Usuarios Logueo(string UsuarioLogueo, string Contrasenia)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("LogueoUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuarioLogueo", UsuarioLogueo);
            cmd.Parameters.AddWithValue("@contrasenia", Contrasenia);

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                string NombreCompleto = (string)lector["nombreCompleto"];

                return new Usuarios(UsuarioLogueo, Contrasenia, NombreCompleto);

            }
            return null;

        }

        public static void AgregarUsuarios(Usuarios pUsu)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("AgregarUsuario", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuarioLogueo", pUsu.UsuarioLogueo);
            cmd.Parameters.AddWithValue("@contrasenia", pUsu.Clave);
            cmd.Parameters.AddWithValue("@nombreCompleto", pUsu.NombreCompleto);

            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            switch ((int)prmRetorno.Value)
            {
                case -1:
                    throw new Exception("El usuario ya existe.");

                case -2:
                    throw new Exception("Error al agregar.");
                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");
            }

        }

        public static void EliminarUsuarios(Usuarios pUsu)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("EliminarUsuario", cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuarioLogueo", pUsu.UsuarioLogueo);


            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();


            switch ((int)prmRetorno.Value)
            {

                case -1:
                    throw new Exception("No existe el usuario.");
                case 1:
                    break;
                case -2:
                    throw new Exception("No se puede eliminar el usuario dado que tiene un pedido asociado.");
                default:
                    throw new Exception("Error desconocido.");

            }

        }

        public static void ModificarUsuarios(Usuarios pUsu)
        {


            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ModificarUsuario", cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuarioLogueo", pUsu.UsuarioLogueo);
            cmd.Parameters.AddWithValue("@contrasenia", pUsu.Clave);
            cmd.Parameters.AddWithValue("@nombreCompleto", pUsu.NombreCompleto);

            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            switch ((int)prmRetorno.Value)
            {
                case -1:
                    throw new Exception("No existe el usuario ingresado.");

                case -2:
                    throw new Exception("Error al modificar en base de datos.");

                case 1:
                    break;
                default:
                    throw new Exception("Error desconocido.");

            }



        }

        public static Usuarios BuscarUsuario(string pUsuario)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("BuscarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuarioLogueo", pUsuario);

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {                
                string Clave = (string)lector["contrasenia"];
                string Nombrecompleto = (string)lector["nombreCompleto"];

                return new Usuarios(pUsuario, Clave, Nombrecompleto);

            }
            return null;
        }
    }
}
