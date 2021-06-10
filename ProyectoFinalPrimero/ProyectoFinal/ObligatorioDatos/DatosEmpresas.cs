using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace ObligatorioDatos
{
    public class DatosEmpresas
    {
        public static void AgregarEmpresas(Empresas pEmp)
        {
            
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("AgregarEmpresa", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", pEmp.RUT);
            cmd.Parameters.AddWithValue("@nombre", pEmp.Nombre);
            cmd.Parameters.AddWithValue("@telefono", pEmp.Telefono);
            cmd.Parameters.AddWithValue("@correoElectronico", pEmp.CorreoElectronico);
           

            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            switch ((int)prmRetorno.Value)
            {
                case -1:
                    throw new Exception("La empresa ya existe.");

                case -2:
                    throw new Exception("Error al agregar.");
               
                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");
            }

        }

        public static void EliminarEmpresas(Empresas pEmp)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("EliminarEmpresa", cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RUT", pEmp.RUT);
            


            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();


            switch ((int)prmRetorno.Value)
            {

                case -1:
                    throw new Exception("No existe la empresa.");
                case 1:
                    break;
                case -2:
                    throw new Exception("No se puede eliminar porque tiene una solicitud el paquete dependiende de esta empresa.");
                case -3:
                    throw new Exception("Error al eliminar la empresa.");
                default:
                    throw new Exception("Error desconocido.");

            }

        }

        public static void ModificarEmpresas(Empresas pEmp)
        {
      

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ModificarEmpresa", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", pEmp.RUT);
            cmd.Parameters.AddWithValue("@nombre", pEmp.Nombre);
            cmd.Parameters.AddWithValue("@telefono", pEmp.Telefono);
            cmd.Parameters.AddWithValue("@correoElectronico", pEmp.CorreoElectronico);
            


            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            switch ((int)prmRetorno.Value)
            {
                case -1:
                    throw new Exception("La empresa no existe.");

                case -2:
                    throw new Exception("Error al modificar.");
                
                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");

            }



        }

        public static Empresas Buscar(int pRUT)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("BuscarEmpresa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", pRUT);

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                string Nombre = (string)lector["nombre"];
                string Telefono = (string)lector["telefono"];
                string CorreoElectronico = (string)lector["correoElectronico"];

                return new Empresas(pRUT, Nombre, Telefono, CorreoElectronico);

            }
            return null;
        }

        public static List<Empresas> Listar()
        {
            List<Empresas> resp = new List<Empresas>();

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ListarEmpresas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                int pRUT = (int)lector["RUT"];
                string pNombre = (string)lector["nombre"];
                string pTelefono = (string)lector["telefono"];
                 string pCorreo = (string)lector["correoElectronico"];

                 resp.Add(new Empresas(pRUT, pNombre, pTelefono, pCorreo));
            }
            cnn.Close();

            return resp;
        }
    }
}
