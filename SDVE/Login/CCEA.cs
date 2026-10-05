using SDVE.Login;

uusing System;
using System.Drawing;
using System.Windows.Forms;

public partial class CCEA : Form
{
    private int carreraSeleccionada = 0;

    public CCEA()
    {
        InitializeComponent();

        Navegacion.ConectarClick(
            pnlCarreraAdmin, Carrera1_Click);

        Navegacion.ConectarClick(
            pnlCarreraContador, Carrera2_Click);

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

        pnlCarreraAdmin.BackColor = carrera == 1
            ? Color.FromArgb(232, 243, 255)
            : Color.White;

        pnlCarreraContador.BackColor = carrera == 2
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
        Navegacion.Abrir(this, new CCS());
    }

    private void picCentroEconomicas_Click(object sender, EventArgs e)
    {
        // Este formulario ya corresponde a Económicas y Administrativas.
    }

    private void btnContinuar_Click(object sender, EventArgs e)
    {
        switch (carreraSeleccionada)
        {
            case 1:
                AbrirCandidatosAdministracion();
                break;

            case 2:
                AbrirCandidatosContador();
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

    private void AbrirCandidatosAdministracion()
    {
        // Sustituye el mensaje por la apertura del formulario real.

        MessageBox.Show(
            "Seleccionaste Administración de Empresas.\n"
            + "Falta conectar su formulario de candidatos.",
            "Administración de Empresas",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void AbrirCandidatosContador()
    {
        // Sustituye el mensaje por la apertura del formulario real.

        MessageBox.Show(
            "Seleccionaste Contador Público.\n"
            + "Falta conectar su formulario de candidatos.",
            "Contador Público",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnVolver_Click(object sender, EventArgs e)
    {
        Close();
    }
}