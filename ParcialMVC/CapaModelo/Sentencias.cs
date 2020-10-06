using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Runtime.CompilerServices;

namespace CapaModelo
{
    public class Sentencias
    {
        Conexion con = new Conexion();
        public OdbcDataAdapter llenarTbl(string tabla1,string tabla2,string tabla3)// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * from productos where estado =1;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }

        public string[] llenarCmb(string tabla, string campo1)
        {

            string[] Campos = new string[300];
            string[] auto = new string[300];
            int i = 0;
            string sql = "SELECT " + campo1 + " FROM " + tabla + " where estado = 1 ;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Campos[i] = reader.GetValue(0).ToString();
                    i++;


                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -" + tabla + "\n -" + campo1); }


            return Campos;



        }

        /// Modelo 2 //

        public DataTable obtener(string tabla, string campo1)
        {

            string sql = "SELECT " + campo1 + " FROM " + tabla + " where estado = 1  ;";

            OdbcCommand command = new OdbcCommand(sql, con.conexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);


            return dt;
        }




        public void procInsertar(string nombre, int linea, int marca, int existencias, int estado)
        {
            int codigo = 0;
            string sql = "SELECT MAX(codigo_producto) FROM productos ;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    codigo = reader.GetInt16(0);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros "); }

            codigo++;

            try
            {
                string insertarProducto = "INSERT INTO productos VALUES ("+codigo+",'"+nombre+"',"+linea+","+marca+","+existencias+","+estado+")";
                OdbcCommand comm3 = new OdbcCommand(insertarProducto, con.conexion());
                comm3.ExecuteNonQuery();
            }
            catch (Exception ex3)
            {
                Console.WriteLine(ex3.Message.ToString() + "error ingresando datos");
            }

        }


        public void eliminarProd(int producto)
        {
          
            try
            {
                string update = "UPDATE productos SET estado = 0 where codigo_producto = "+producto+"; ";
                OdbcCommand comm3 = new OdbcCommand(update, con.conexion());
                comm3.ExecuteNonQuery();
            }
            catch (Exception ex3)
            {
                Console.WriteLine(ex3.Message.ToString() + "error ingresando datos");
            }

        }


    }
}
