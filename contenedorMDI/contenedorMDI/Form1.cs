using CapaVista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contenedorMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mantenimientoInsertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoInsertar frmI = new frmMantenimientoInsertar();
            frmI.MdiParent = this;
            frmI.Show();
        }

        private void mantenimientoEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoEliminar frm = new frmMantenimientoEliminar();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
