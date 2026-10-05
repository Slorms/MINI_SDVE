using SDVE.Login;
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class CCS : Form
{
    private int carreraSeleccionada = 0;

    public CCS()
    {
        InitializeComponent();

        Navegacion.ConectarClick(
            pnlCarreraEnfermeria, Carrera1_Click);

        Navegacion.ConectarClick(
            pnlCarreraNutricion, Carrera2_Click);

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

        pnlCarreraEnfermeria.BackColor = carrera == 1
            ? Color.FromArgb(232, 243, 255)
            : Color.White;

        pnlCarreraNutricion.BackColor = carrera == 2
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
        Navegacion.Abrir(this, new CCB());
    }

    private void picCentroSalud_Click(object sender, EventArgs e)
    {
        // Este formulario ya corresponde a Ciencias de la Salud.
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
                AbrirCandidatosEnfermeria();
                break;

            case 2:
                AbrirCandidatosNutricion();
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

    private void AbrirCandidatosEnfermeria()
    {
        // Sustituye el mensaje por la apertura del formulario real.

        MessageBox.Show(
            "Seleccionaste Licenciatura en Enfermería.\n"
            + "Falta conectar su formulario de candidatos.",
            "Enfermería",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void AbrirCandidatosNutricion()
    {
        // Sustituye el mensaje por la apertura del formulario real.

        MessageBox.Show(
            "Seleccionaste Licenciatura en Nutrición.\n"
            + "Falta conectar su formulario de candidatos.",
            "Nutrición",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnVolver_Click(object sender, EventArgs e)
    {
        Close();
    }
}