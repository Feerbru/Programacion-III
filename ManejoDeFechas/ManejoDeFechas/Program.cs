using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeFechas
{
    class Program
    {
        /*Realice una clase utilitaria de manejo de tiempo y fechas que tenga al menos:
         * ObtenerDiasCalendario() obtiene los días entre dos fechas
         * ObtenerDiasLaborables() obtiene los días laborables entre dos fechas
         * SumarDiasLaborables() obtiene una fecha sumando una cantidad de días a una fecha inicial
         * Tenga en cuenta fines de semanas y feriados
         * Puede guardar los feriados en un arreglo*/
        static void Main(string[] args)
        {
            DateTime fecha1 = new DateTime(2021,9,5);
            DateTime fecha2 = new DateTime(2021,10,5);
            DateTime[] feriados = { new DateTime(1,6,20), new DateTime(1,7,9),new DateTime(1,12,25)};

            ObtenerDiasCalendarios(fecha1, fecha2);
            int diasLaborables = ObtenerDiasLaborables(fecha1,fecha2);
            Console.WriteLine($"Los dias laborables son : {diasLaborables}.");
            SumarDiasLaborables(fecha1,feriados,7);
            Console.ReadKey();

        }
        public static void ObtenerDiasCalendarios(DateTime fecha1, DateTime fecha2)
        {
            TimeSpan dias = fecha2.Date - fecha1.Date;
            Console.WriteLine($"Los dias entre las fechas {fecha1.ToShortDateString()} y {fecha2.ToShortDateString()} son {dias.Days} dias.");
        }
        public static int ObtenerDiasLaborables(DateTime fecha1, DateTime fecha2)
        {
            TimeSpan dias = new TimeSpan();

            while (fecha1 < fecha2)
            {
                if (!EsFinDeSemana(fecha1))
                {
                    dias = dias.Add( new TimeSpan(1, 0, 0, 0)); ;
                }
                fecha1 = fecha1.AddDays(1);
            }
            return dias.Days;
        }
        public static bool EsFinDeSemana(DateTime fecha)
        {
            return (fecha.DayOfWeek == DayOfWeek.Sunday || fecha.DayOfWeek == DayOfWeek.Saturday);
        }

        public static void SumarDiasLaborables(DateTime fechaInicial, DateTime[] feriados, int cantidadDias)
        {
            //fechaInicial.AddDays(cantidadDias);

            int dias = cantidadDias -1;

            while (dias > 0)
            {
                if (!EsFinDeSemana(fechaInicial) && !EsFeriado(feriados, fechaInicial))
                {
                    fechaInicial = fechaInicial.AddDays(1);
                    dias--;
                }
                else
                {
                    fechaInicial = fechaInicial.AddDays(1);
                   
                }
                //fechaInicial = fechaInicial.AddDays(1);
            }
            Console.WriteLine($"La fecha nueva es {fechaInicial.ToShortDateString()} luego de sumarle los {cantidadDias} laborales.");

        }
        public static bool EsFeriado(DateTime [] feriados, DateTime fecha)
        {
            bool esFeriado = false;

            for (int i = 0; i < feriados.Length; i++)
            {
                esFeriado = (feriados[i].Month == fecha.Month && feriados[i].Day == fecha.Day);
            }
            return esFeriado;
        }
    }
}
