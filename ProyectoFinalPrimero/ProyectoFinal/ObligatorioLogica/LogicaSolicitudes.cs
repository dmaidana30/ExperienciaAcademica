using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using ObligatorioDatos;

namespace ObligatorioLogica
{
    public class LogicaSolicitudes
    {
        public static void AgregarSolicitud(SolicitudesEntrega solE) 
        {
            DatosSolicitudes.AgregarSolicitud(solE);
        }

        public static List<SolicitudesEntrega> Listar()
        {
            List<SolicitudesEntrega> resp = new List<SolicitudesEntrega>();
            resp.AddRange(DatosSolicitudes.Listar());
            return resp;
        }

        public static List<SolicitudesEntrega> ListarDepCam()
        {
            List<SolicitudesEntrega> resp = new List<SolicitudesEntrega>();
            resp.AddRange(DatosSolicitudes.ListarDepCam());
            return resp;
        }

        public static List<SolicitudesEntrega> ListarXFecha(DateTime pFecha)
        {
            List<SolicitudesEntrega> resp = new List<SolicitudesEntrega>();
            resp.AddRange(DatosSolicitudes.ListarXFecha(pFecha));
            return resp;
        }

        public static void CambiarEstado(SolicitudesEntrega pSol)
        {
            DatosSolicitudes.ModificarEstado(pSol);
        }

        public static SolicitudesEntrega buscar(Paquetes paq)
        {
            SolicitudesEntrega solE = DatosSolicitudes.Buscar(paq);
            return solE;
        }


    }
}
