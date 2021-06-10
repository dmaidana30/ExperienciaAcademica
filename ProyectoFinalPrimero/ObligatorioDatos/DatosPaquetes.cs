using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace ObligatorioDatos
{
    public class DatosPaquetes
    {      
        public static void AgregarPaquetes(Paquetes pPaq)
        {
      
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("AgregarPaquete", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", pPaq.MiEmpresa.RUT);
            cmd.Parameters.AddWithValue("@numeroP", pPaq.NumeroP);
            cmd.Parameters.AddWithValue("@peso", pPaq.Peso);
            cmd.Parameters.AddWithValue("@tipoDePaquete", pPaq.TipoDePaquete);
             cmd.Parameters.AddWithValue("@descripción",pPaq.Descripcion);

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
                    throw new Exception("El paquete ya existe.");
                case -3:
                    throw new Exception("El peso del paquete es negativo.");
                case -4:
                    throw new Exception("El tipo de paquete es incorrecto.");
                case -5:
                    throw new Exception("Error al agregar paquete.");
                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");
            }

        }

        public static void EliminarPaquetes(Paquetes pPaq)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("EliminarPaquete", cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RUT", pPaq.MiEmpresa.RUT);
            cmd.Parameters.AddWithValue("@numeroP", pPaq.NumeroP);


            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();


            switch ((int)prmRetorno.Value)
            {

                case -1:
                    throw new Exception("No existe el paquete.");
                case 1:
                    break;
                case -2:
                    throw new Exception("No se puede eliminar el paquete.");
                default:
                    throw new Exception("Error desconocido.");

            }

        }

        public static void ModificarPaquetes(Paquetes pPaq)
        {


            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ModificarPaquete", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.AddWithValue("@RUT", pPaq.MiEmpresa.RUT);
            cmd.Parameters.AddWithValue("@numeroP", pPaq.NumeroP);
            cmd.Parameters.AddWithValue("@peso", pPaq.Peso);
            cmd.Parameters.AddWithValue("@tipoDePaquete", pPaq.TipoDePaquete);
             cmd.Parameters.AddWithValue("@descripción",pPaq.Descripcion);


            SqlParameter prmRetorno = new SqlParameter();
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            switch ((int)prmRetorno.Value)
            {
                case -1:
                    throw new Exception("El paquete no existe.");

                case -2:
                    throw new Exception("El peso del paquete es negativo.");
                case -3:
                    throw new Exception("El tipo de paquete es incorrecto.");
                
                case -4:
                    throw new Exception("Error al modificar paquete.");
                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");

            }



        }

        public static Paquetes Buscar(int pRUT, int pNumero)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("BuscarPaquete", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", pRUT);
            cmd.Parameters.AddWithValue("@numeroP", pNumero);

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
               
                double pPeso = (double)lector["peso"];
                string pTipoDePaquete = (string)lector["tipoDePaquete"];
                string pDescripción = (string)lector["descripción"];

                Empresas emp = DatosEmpresas.Buscar(pRUT);

                return new Paquetes(pNumero, pPeso, pTipoDePaquete, pDescripción, emp);

            }
            return null;
        }

        public static List<Paquetes> Listar()
        {
            List<Paquetes> resp = new List<Paquetes>();

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ListarPaquetesSinSolicitud", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                /*RUT,numeroP,peso,tipoDePaquete,descripción*/
                int pRUT = (int)lector["RUT"];
                int pNumeroP = (int)lector["numeroP"];
                double pPeso = (double)lector["peso"];
                string pTipoDePaquete = (string)lector["tipoDePaquete"];
                string pDescripción = (string)lector["descripción"];

               Empresas emp = DatosEmpresas.Buscar(pRUT);
               resp.Add(new Paquetes(pNumeroP, pPeso, pTipoDePaquete, pDescripción, emp));
                
            }
            cnn.Close();

            return resp;
        }

        public static List<Paquetes> ListarXEmp(int plRUT)
        {
            List<Paquetes> resp = new List<Paquetes>();

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ListarPaquetesXEmpresa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", plRUT);

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                /*RUT,numeroP,peso,tipoDePaquete,descripción*/
                
                int pNumeroP = (int)lector["numeroP"];
                double pPeso = (double)lector["peso"];
                string pTipoDePaquete = (string)lector["tipoDePaquete"];
                string pDescripción = (string)lector["descripción"];

                Empresas emp = DatosEmpresas.Buscar(plRUT);
                resp.Add(new Paquetes(pNumeroP, pPeso, pTipoDePaquete, pDescripción, emp));

            }
            cnn.Close();

            return resp;
        }

        }
    }

