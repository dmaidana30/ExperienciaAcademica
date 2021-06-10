using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace ObligatorioDatos
{
    public class DatosSolicitudes
    {
        public static void AgregarSolicitud(SolicitudesEntrega pSolE)
        {

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("AgregarRegistro", cnn);

            cmd.CommandType = CommandType.StoredProcedure;
        
	
            cmd.Parameters.AddWithValue("@RUT", pSolE.MiPaquete.MiEmpresa.RUT);
            cmd.Parameters.AddWithValue("@numeroP", pSolE.MiPaquete.NumeroP);
            cmd.Parameters.AddWithValue("@fechaEntrega", pSolE.Fecha);
            cmd.Parameters.AddWithValue("@direccion", pSolE.Direccion);
            cmd.Parameters.AddWithValue("@nombreDest",pSolE.NombreDes);
            cmd.Parameters.AddWithValue("@usuarioLogueo", pSolE.MiUsuario.UsuarioLogueo);



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

                case -2:
                    throw new Exception("No hay usuario.");
                case -3:
                    throw new Exception("La fecha debe de ser posterior a la actual.");
                case -4:
                    throw new Exception("El paquete ya tiene una solicitud vinculada.");
                case -5:
                    throw new Exception("Error al agregar.");

                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");
            }

        }
        public static List<SolicitudesEntrega> Listar()
        {
            List<SolicitudesEntrega> resp = new List<SolicitudesEntrega>();

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ListarSolicitudes", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
         
                int pNumeroInterno = (int)lector["numeroInterno"];
                DateTime pFecha = (DateTime)lector["fechaEntrega"];
                string pNombreDes = (string)lector["nombreDest"];
                string pDireccion = (string)lector["direccion"];
                 string pEstadoActual = (string)lector["estadoActual"];
                
                int pRUT = (int)lector["RUT"];
                int pNumeroP = (int)lector["numeroP"];

                Paquetes paq = DatosPaquetes.Buscar(pRUT,pNumeroP);
                string pUsuLog = (string)lector["usuarioLogueo"];
                Usuarios pUsu = DatosUsuarios.BuscarUsuario(pUsuLog);


                resp.Add(new SolicitudesEntrega(pNumeroInterno,pFecha,pNombreDes,pDireccion,pEstadoActual,pUsu,paq));
            }
            cnn.Close();

            return resp;
        }
        public static List<SolicitudesEntrega> ListarDepCam()
        {
            List<SolicitudesEntrega> resp = new List<SolicitudesEntrega>();

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ListarDepCam", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {

                int pNumeroInterno = (int)lector["numeroInterno"];
                DateTime pFecha = (DateTime)lector["fechaEntrega"];
                string pNombreDes = (string)lector["nombreDest"];
                string pDireccion = (string)lector["direccion"];
                string pEstadoActual = (string)lector["estadoActual"];

                int pRUT = (int)lector["RUT"];
                int pNumeroP = (int)lector["numeroP"];

                Paquetes paq = DatosPaquetes.Buscar(pRUT, pNumeroP);
                string pUsuLog = (string)lector["usuarioLogueo"];
                Usuarios pUsu = DatosUsuarios.BuscarUsuario(pUsuLog);


                resp.Add(new SolicitudesEntrega(pNumeroInterno, pFecha, pNombreDes, pDireccion, pEstadoActual, pUsu, paq));
            }
            cnn.Close();

            return resp;
        }
        public static List<SolicitudesEntrega> ListarXFecha(DateTime pFecha)
        {
            List<SolicitudesEntrega> resp = new List<SolicitudesEntrega>();

            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ListarXFecha", cnn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@fecha", pFecha);

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {

                int pNumeroInterno = (int)lector["numeroInterno"];                
                string pNombreDes = (string)lector["nombreDest"];
                string pDireccion = (string)lector["direccion"];
                string pEstadoActual = (string)lector["estadoActual"];

                int pRUT = (int)lector["RUT"];
                int pNumeroP = (int)lector["numeroP"];

                Paquetes paq = DatosPaquetes.Buscar(pRUT, pNumeroP);
                string pUsuLog = (string)lector["usuarioLogueo"];
                Usuarios pUsu = DatosUsuarios.BuscarUsuario(pUsuLog);


                resp.Add(new SolicitudesEntrega(pNumeroInterno, pFecha, pNombreDes, pDireccion, pEstadoActual, pUsu, paq));
            }
            cnn.Close();

            return resp;
        }


        public static void ModificarEstado(SolicitudesEntrega pSol)
        {


            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("ModificarEstado", cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroInt ", pSol.NumeroInterno);
            cmd.Parameters.AddWithValue("@EstadoActual ", pSol.EstadoActual);

            SqlParameter prmRetorno = new SqlParameter();

            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            switch ((int)prmRetorno.Value)
            {
                case -1:
                    throw new Exception("Error tipo de estado.");

                case -2:
                    throw new Exception("Solicitud no existe.");

                case -3:
                    throw new Exception("Error al modificar.");

                case 1:
                    break;

                default:
                    throw new Exception("Error desconocido.");

            }



        }
        public static SolicitudesEntrega Buscar(Paquetes pPaq)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand cmd = new SqlCommand("BuscarSolicitud", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RUT", pPaq.MiEmpresa.RUT);
            cmd.Parameters.AddWithValue("@numeroP", pPaq.NumeroP) ;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                int pNumeroInterno = (int)lector["numeroInterno"];
                DateTime pFecha = (DateTime)lector["fechaEntrega"];
                string pNombreDes = (string)lector["nombreDest"];
                string pDireccion = (string)lector["direccion"];
                string pEstadoActual = (string)lector["estadoActual"];

                int pRUT = pPaq.MiEmpresa.RUT;
                int pNumeroP = pPaq.NumeroP;

                Paquetes paq = DatosPaquetes.Buscar(pRUT, pNumeroP);
                string pUsuLog = (string)lector["usuarioLogueo"];
                Usuarios pUsu = DatosUsuarios.BuscarUsuario(pUsuLog);

                return new SolicitudesEntrega(pNumeroInterno, pFecha, pNombreDes, pDireccion, pEstadoActual, pUsu, paq);

            }
            return null;
        }
    }
}
