using SDVE.Login;
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class CCB : Form
{
    private int carreraSeleccionada = 0;

    public CCB()
    {
        InitializeComponent();

        Navegacion.ConectarClick(
            pnlCarreraSistemas, Carrera1_Click);

        Navegacion.ConectarClick(
            pnlCarreraInformatica, Carrera2_Click);

        Navegacion.ConectarClick(
            picCentroBasicas, picCentroBasicas_Click);

        Navegacion.ConectarClick(
            picCentroSalud, picCentroSalud_Click);

        Navegacion.ConectarClick(
            picCentroEconomicas, picCentroEconomicas_Click);

        Navegacion.ConectarClick(
            btnContinuar, btnContinuar_Click);

        Navegacion.ConectarClick(
            btnVolver, btnVolver_Click);

        SeleccionarCarrera(0);
    }

    private void SeleccionarCarrera(int carrera)
    {
        carreraSeleccionada = carrera;

        pnlCarreraSistemas.BackColor = carrera == 1
            ? Color.FromArgb(232, 243, 255)
            : Color.White;

        pnlCarreraInformatica.BackColor = carrera == 2
            ? Color.FromArgb(232, 243, 255)
            : Color.White;
    }

    private void Carrera1_Click(object sender, EventArgs e)
    {
        SeleccionarCarrera(1);
    }

    private void Carrera2_Click(object sender, EventArgs e)
    {
        SeleccionarCarrera(2);
    }

    private void picCentroBasicas_Click(object sender, EventArgs e)
    {
        // Este formulario ya corresponde a Ciencias Básicas.
    }

    private void picCentroSalud_Click(object sender, EventArgs e)
    {
        Navegacion.Abrir(this, new CCS());
    }

    private void picCentroEconomicas_Click(object sender, EventArgs e)
    {
        Navegacion.Abrir(this, new CCEA());
    }

    private void btnContinuar_Click(object sender, EventArgs e)
    {
        switch (carreraSeleccionada)
        {
            case 1:
                AbrirCandidatosSistemas();
                break;

            case 2:
                AbrirCandidatosInformatica();
                break;

            default:
                MessageBox.Show(
                    "Selecciona una carrera para continuar.",
                    "Selección de carrera",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                break;
        }
    }

    private void AbrirCandidatosSistemas()
    {
        // Sustituye el mensaje por la apertura del formulario real.
        // Ejemplo:
        // Navegacion.Abrir(this, new NombreRealDelFormulario());

        MessageBox.Show(
            "Seleccionaste Ingeniería en Sistemas Computacionales.\n"
            + "Falta conectar su formulario de candidatos.",
            "Sistemas Computacionales",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void AbrirCandidatosInformatica()
    {
        // Sustituye el mensaje por la apertura del formulario real.

        MessageBox.Show(
            "Seleccionaste Informática y Tecnologías Computacionales.\n"
            + "Falta conectar su formulario de candidatos.",
            "Informática",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnVolver_Click(object sender, EventArgs e)
    {
        Close();
    }
}
