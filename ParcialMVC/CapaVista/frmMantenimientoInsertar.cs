using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using CapaControlador;

namespace CapaVista
{
    public partial class frmMantenimientoInsertar : Form
    {
        Controlador cn = new Controlador();

        public frmMantenimientoInsertar()
        {
            InitializeComponent();
            fillData();
        }

        public void fillData()
        {
            string tabla1 = "productos";
            string tabla2 = "lineas";
            string tabla3 = "marcas";
            string campo = "nombre_linea";
            DataTable dt = cn.llenarTbl(tabla1,tabla2,tabla3);
            dgvMostrar.DataSource = dt;
            llenarse(tabla2,campo,cmbLinea);
            llenarse(tabla2, "codigo_linea", cmbIdLinea);
            llenarse(tabla3, "nombre_marca", cmbMarca);
            llenarse(tabla3, "codigo_marca", cmbIdMarca);
        }


        public void llenarse(string tabla, string campo1, ComboBox cmb)
        {
            
            string tbl = tabla;
            string cmp1 = campo1;


            //cmbLinea.ValueMember = "codigo_linea";
            cmb.DisplayMember = "nombre";

            string[] items = cn.items(tabla, campo1);



            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cmb.Items.Add(items[i]);
                    }
                }

            }

            var dt2 = cn.enviar(tabla, campo1);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo1]));
              
            }

            cmb.AutoCompleteCustomSource = coleccion;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }


        private void frmMantenimientoInsertar_Load(object sender, EventArgs e)
        {

        }

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIdLinea.SelectedIndex = cmbLinea.SelectedIndex;
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIdMarca.SelectedIndex = cmbMarca.SelectedIndex;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            fillData();
            int estado =0;
            if (cmbEstado.SelectedIndex==0)
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }

            cn.translado(txtProducto.Text.ToString(),int.Parse(cmbIdLinea.SelectedItem.ToString()),int.Parse(cmbIdMarca.SelectedItem.ToString()),int.Parse(txtExistencia.Text),estado);
        }
    }
}
