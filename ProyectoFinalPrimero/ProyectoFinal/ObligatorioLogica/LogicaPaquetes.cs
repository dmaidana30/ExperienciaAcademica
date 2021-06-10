using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObligatorioEntidadesCompartidas;
using ObligatorioDatos;


namespace ObligatorioLogica
{
    public class LogicaPaquetes
    {
        public static void AgregarPaquetes(Paquetes pPaq)
        {
            DatosPaquetes.AgregarPaquetes(pPaq);
        }

        public static void ModificarPaquetes(Paquetes pPaq)
        {
            DatosPaquetes.ModificarPaquetes(pPaq);
        }

        public static void EliminarPaquetes(Paquetes pPaq)
        {
            DatosPaquetes.EliminarPaquetes(pPaq);

        }

        public static Paquetes  buscar(int pRUT,int pNumero)
        {
            Paquetes paq = DatosPaquetes.Buscar(pRUT, pNumero);
            return paq;
       }

        public static List<Paquetes> Listar()
        {
            List<Paquetes> resp = new List<Paquetes>();
            resp.AddRange(DatosPaquetes.Listar());
            return resp;
        }

        public static List<Paquetes> ListarXEmp(int pRUT)
        {
            List<Paquetes> resp = new List<Paquetes>();
            resp.AddRange(DatosPaquetes.ListarXEmp(pRUT));
            return resp;
        }
    }
}
