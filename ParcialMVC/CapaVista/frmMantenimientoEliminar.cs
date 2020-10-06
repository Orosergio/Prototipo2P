using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
namespace CapaVista
{
    public partial class frmMantenimientoEliminar : Form
    {
        Controlador cn = new Controlador();
        public frmMantenimientoEliminar()
        {
            InitializeComponent();
            fillData();
        }

        public void fillData()
        {
            string tabla1 = "productos";
            string tabla2 = "lineas";
            string tabla3 = "marcas";
            string campo = "nombre_producto";
            DataTable dt = cn.llenarTbl(tabla1, tabla2, tabla3);
            dgvProducto.DataSource = dt;
            llenarse(tabla1, campo, cmbProducto);
            llenarse(tabla1,"codigo_producto",cmbIdProducto);
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
        private void frmMantenimientoEliminar_Load(object sender, EventArgs e)
        {

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIdProducto.SelectedIndex = cmbProducto.SelectedIndex;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            fillData();
            cn.TransladoEliminar(int.Parse(cmbIdProducto.SelectedItem.ToString()));
        }
    }
}
