using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using ObligatorioDatos;

namespace ObligatorioLogica
{
    public class LogicaEmpresas
    {

        public static Empresas Buscar(int pRUT)
        {
            Empresas emp = DatosEmpresas.Buscar(pRUT);            
            return emp;
        }
        public static void AgregarEmpresas(Empresas pEmp)
        {
           DatosEmpresas.AgregarEmpresas(pEmp);
        }

        public static void ModificarEmpresas(Empresas pEmp)
        {
            DatosEmpresas.ModificarEmpresas(pEmp);
        }

        public static void EliminarEmpresa(Empresas pEmp)
        {
            DatosEmpresas.EliminarEmpresas(pEmp);

        }

        public static List<Empresas> Listar()
        {
            List<Empresas> resp = new List<Empresas>();
            resp.AddRange(DatosEmpresas.Listar());
            return resp;
        }
    }
}
