using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOchoReinas
{
    public partial class frmPrincipal : Form
    {
        private Metodos metodos;

        private Button btnNext;
        private Button btnPrev;

        public frmPrincipal()
        {
            InitializeComponent();
            metodos = new Metodos();
            InitializeBoard();
            InitializeButtons();
            ShowSolution(0);
        }

        //Inicializa los botones
        private void InitializeButtons()
        {
            btnNext = new Button();
            btnNext.Text = "Siguiente";
            btnNext.Location = new Point(250, Metodos.BoardSize * Metodos.SquareSize + 20);
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            btnPrev = new Button();
            btnPrev.Text = "Anterior";
            btnPrev.Location = new Point(150, Metodos.BoardSize * Metodos.SquareSize + 20);
            btnPrev.Click += BtnPrev_Click;
            this.Controls.Add(btnPrev);
        }

        //Evento botón Siguiente
        private void BtnNext_Click(object sender, EventArgs e)
        {
            ShowNextSolution();
        }

        //Evento botón Anterior
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            ShowPreviousSolution();
        }

        //Muestra la siguiente solución en la interfaz gráfica
        private void ShowNextSolution()
        {
            if (metodos.CurrentSolutionIndex < metodos.Solutions.Count - 1)
            {
                metodos.CurrentSolutionIndex++;
                ShowSolution(metodos.CurrentSolutionIndex);
            }
        }

        //Muestra la solución anterior en la interfaz
        private void ShowPreviousSolution()
        {
            if (metodos.CurrentSolutionIndex > 0)
            {
                metodos.CurrentSolutionIndex--;
                ShowSolution(metodos.CurrentSolutionIndex);
            }
        }

        //Muestra una solución específica en la interfaz
        private void ShowSolution(int index)
        {
            metodos.CurrentSolutionIndex = index;

            if (index >= 0 && index < metodos.Solutions.Count)
            {
                this.Text = $"Ever CR - Problema de las 8 Reinas - Solución {index + 1}/{metodos.Solutions.Count}";
                this.Invalidate();
            }
            else
            {
                this.Text = "Sin soluciones"; //Si no hay soluciones, muestra mensaje de error
            }
        }

        //Inicializa el tamaño del formulario basándose en el tamaño del tablero
        private void InitializeBoard()
        {
            this.Size = new Size(Metodos.BoardSize * Metodos.SquareSize + 20, Metodos.BoardSize * Metodos.SquareSize + 100);
            this.Paint += PaintForm;
        }

        //Maneja el evento de pintura del formulario
        private void PaintForm(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (metodos.Solutions.Count > 0)
            {
                metodos.DrawBoard(g);
                metodos.DrawQueens(g, metodos.Solutions[metodos.CurrentSolutionIndex]);
            }
        }
    }
}


