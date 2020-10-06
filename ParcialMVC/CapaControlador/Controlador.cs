using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;
using System.Data;
using System.Data.Odbc;
namespace CapaControlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();
        public DataTable llenarTbl(string tabla1,string tabla2, string tabla3)
        {
            OdbcDataAdapter dt = sn.llenarTbl(tabla1,tabla2,tabla3);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public string[] items(string tabla, string campo1)
        {
            string[] Items = sn.llenarCmb(tabla, campo1);

            return Items;


        }

        ///Controlador 2///

        public DataTable enviar(string tabla, string campo1)
        {

            var dt1 = sn.obtener(tabla, campo1);

            return dt1;
        }


        public void translado(string nombre, int linea, int marca, int existencias, int estado)
        {
            sn.procInsertar(nombre,linea,marca,existencias,estado);
        }

        public void TransladoEliminar(int producto)
        {
            sn.eliminarProd(producto);
        }

    }
}
