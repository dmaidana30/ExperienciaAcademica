using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioEntidadesCompartidas
{
    public class Empresas
    {
        #region Atributos

        string nombre;
        int rut;
        string telefono;
        string correoElectronico;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim().Length > 50)
                    throw new Exception("La extensión del nombre debe ser menor o igual a 50.");
                else if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacío.");
                else
                    nombre = value;
            }
        }

        
        public int RUT
        {
            get { return rut; }
            set
            {
                if (value < 99 | value > 999)
                    throw new Exception("El valor debe ser de 3 digitos");
                rut = value;
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (value.Trim().Length > 50)
                    throw new Exception("La extensión del nombre debe ser menor o igual a 50.");
                if (value.Trim() == "")
                    throw new Exception("El telefonoa no puede ser vacio");
                telefono = value;
            }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set
            {
                if (value.Trim().Length > 50)
                    throw new Exception("La extensión del correo electronico debe ser menor o igual a 50.");
                if (value.Trim() == "")
                    throw new Exception("El campo no puede ser vacio");
                correoElectronico = value;
            }

        }

        #endregion

        #region ConstructoresCompletos

        public Empresas(int pRUT, string pNombre, string pTelefono, string pCorreoElectronico)
        {
            RUT = pRUT;
            Nombre = pNombre;
            Telefono = pTelefono;
            CorreoElectronico = pCorreoElectronico;
        }

        #endregion

        #region Operaciones

        public override string ToString()
        {

            return "Nombre: " + nombre + " | RUT: " + rut + " | Telefono: " + telefono + " | Email: " + correoElectronico;
        }
        #endregion
    }
}
