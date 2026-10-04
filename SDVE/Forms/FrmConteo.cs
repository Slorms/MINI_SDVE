using SDVE.Conteo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SDVE.Forms
{
    public partial class FrmConteo : Form
    {
        public FrmConteo()
        {
            InitializeComponent();

            // agregamos las elecciones
            cmbEleccion.Items.Add("Sociedad de Alumnos");
            cmbEleccion.Items.Add("Consejo Universitario");
            cmbEleccion.Items.Add("Consejo de Representantes");

            // agregamos los tipos de agrupacion
            cmbAgrupacion.Items.Add("Grupo");
            cmbAgrupacion.Items.Add("Carrera");
            cmbAgrupacion.Items.Add("Centro");

            // seleccionamos la primera opcion
            cmbEleccion.SelectedIndex = 0;
            cmbAgrupacion.SelectedIndex = 0;
        }

        private void FrmConteo_Load(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
