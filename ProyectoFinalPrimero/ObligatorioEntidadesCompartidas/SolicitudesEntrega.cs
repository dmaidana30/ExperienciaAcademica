using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioEntidadesCompartidas
{
    public class SolicitudesEntrega
    {
        #region Atributos

        int numeroInterno;
        DateTime fecha;
        string nombreDes;
        string direccion;
        string estadoActual;
        Usuarios miUsuario;
        Paquetes miPaquete;

        #endregion

        #region Propiedades

        public int NumeroInterno
        {
            get { return numeroInterno; }
            set
            {  numeroInterno = value;}
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string NombreDes
        {
            get { return nombreDes; }
            set
            {
                if (value.Trim().Length > 20)
                    throw new Exception("La extensión del nombre debe ser menor o igual a 20.");
                else if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacío.");
                else
                nombreDes = value;
            }
        }
        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Trim().Length > 30)
                    throw new Exception("La extensión de la direccion debe ser menor o igual a 30.");
                else if (value.Trim() == "")
                    throw new Exception("La direccion no puede estar vacío.");
                else
                direccion = value;
            }
        }
        public string EstadoActual
        {
            get { return estadoActual; }
            set
            {
                if (value.ToLower() != "endeposito" && value.ToLower() != "encamino" && value.ToLower() != "entregado")
                    throw new Exception("Debe ingresar un tipo de estado válido.");
                estadoActual = value;
            }
        }
        public Usuarios MiUsuario
        {
            get { return miUsuario; }
            set
            {
                if (value == null)
                    throw new Exception("El usuario no existe");

                miUsuario = value;

            }
        }
        public Paquetes MiPaquete
        {
            get { return miPaquete; }
            set
            {
                if (value == null)
                    throw new Exception("El paquete no existe");

                miPaquete = value;

            }
        }

        #endregion

        #region Constructor

        public SolicitudesEntrega(int pNumeroInterno, DateTime pFecha, string pNombreDes, string pDireccion, string pEstadoActual, Usuarios pMiUsuario, Paquetes pMiPaquete)
        {
            NumeroInterno = pNumeroInterno;
            Fecha = pFecha;
            NombreDes = pNombreDes;
            Direccion = pDireccion;
            EstadoActual = pEstadoActual;
            MiUsuario = pMiUsuario;
            MiPaquete = pMiPaquete;
        }

        #endregion

        #region
        public override string ToString()
        {

            return "Numero interno: " + numeroInterno + " Fecha: " + fecha.ToString("dd - MM - yy") + "Nombre destinatario" + nombreDes + "direccion" + direccion + "Estado actual " + estadoActual;
        }

        #endregion
    }
}
