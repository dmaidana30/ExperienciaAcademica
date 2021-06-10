using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioEntidadesCompartidas
{
    public class Paquetes
    {
        #region Atributos

        int numeroP;
        double peso;
        string tipoDePaquete;
        string descripcion;
        Empresas miEmpresa;

        #endregion

        #region Propiedades

        public int NumeroP
        {
            get { return numeroP; }
            set
            {
                if (value <= 0)
                    throw new Exception("el Numero no puede ser negativo o 0");
                numeroP = value;}
        }


        public double Peso
        {
            get { return peso; }
            set 
            {
                if (value <= 0)
                    throw new Exception("el peso no puede ser negativo o 0");
                peso = value;

            }
        }


        public string TipoDePaquete
        {
            get{return tipoDePaquete;}
            set
            {
                if (value.ToLower() != "comun" && value.ToLower() != "bulto" && value.ToLower() != "fragil")               
                    throw new Exception("Debe ingresar un tipo de paquete válido.");      
                tipoDePaquete = value;
               
            }
        }


        public string Descripcion
        {
            get { return descripcion; }
            set 
            {
                if (value.Trim().Length > 50)
                    throw new Exception("La extensión de la descripccion  debe ser menor o igual a 50.");
                else if (value.Trim() == "")
                    throw new Exception("La descripcion no puede estar vacío.");
                else
                descripcion = value;
            }
        }


        public Empresas MiEmpresa
        {
            get { return miEmpresa; }
            set 
            {
                if (value == null)
                    throw new Exception("La empresa no existe");

                miEmpresa = value;

            }
        }

        public int RutEmpresa
        {
            get { return miEmpresa.RUT; }
        }

        #endregion

        #region Constructores

        public Paquetes(int pNumeroP, double pPeso, string pTipoDePaquete, string pDescripcion, Empresas pMiEmpresa)
        {
            NumeroP = pNumeroP;
            Peso = pPeso;
            TipoDePaquete = pTipoDePaquete;
            Descripcion = pDescripcion;
            MiEmpresa = pMiEmpresa;

        }

        #endregion        

        #region Operaciones

        public override string ToString()
        {

            return "El paquete Nº; " + numeroP + " | Peso: " + peso + " | Tipo de paquete: " + tipoDePaquete + " | Descripcion: " + descripcion + " | Empresa: " + miEmpresa.Nombre +" | RUT: " + miEmpresa.RUT ;
        }
        #endregion
    }
}
