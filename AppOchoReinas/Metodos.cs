using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOchoReinas
{
    public class Metodos
    {
        public const int BoardSize = 8; //Tamaño del tablero (8x8)
        public const int SquareSize = 60; //Tamaño por cada cuadro
        private List<List<int>> solutions; //Lista de soluciones
        private int currentSolutionIndex; //Indice de la solución

        public Metodos()
        {
            solutions = new List<List<int>>();
            ResolverProblema(new List<int>(), 0); //Inicia la solución
        }

        public List<List<int>> Solutions => solutions;

        //Accede y modifica el indice actual
        public int CurrentSolutionIndex
        {
            get => currentSolutionIndex;
            set => currentSolutionIndex = value;
        }

        public void ResolverProblema(List<int> queens, int row)
        {
            if (row == BoardSize)
            {
                solutions.Add(new List<int>(queens)); //Agrega una solución encontrada a la lista
                return;
            }

            for (int col = 0; col < BoardSize; col++)
            {
                if (validarPosicion(queens, row, col))
                {
                    queens.Add(col);
                    ResolverProblema(queens, row + 1); //Aplicación de recursividad para buscar soluciones
                    queens.RemoveAt(queens.Count - 1);
                }
            }
        }

        public bool validarPosicion(List<int> queens, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (queens[i] == col || queens[i] - i == col - row || queens[i] + i == col + row)
                {
                    return false;
                }
            }
            return true;
        }

        // Dibujar el tablero
        public void DrawBoard(Graphics g)
        {
            
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Brush brush = (i + j) % 2 == 0 ? Brushes.LightBlue : Brushes.White;
                    g.FillRectangle(brush, j * SquareSize, i * SquareSize, SquareSize, SquareSize);
                }
            }
        }

        //Dibujar las reinas
        public void DrawQueens(Graphics g, List<int> queens)
        {
            for (int i = 0; i < queens.Count; i++)
            {
                int x = queens[i] * SquareSize;
                int y = i * SquareSize;
                g.FillEllipse(Brushes.Blue, x, y, SquareSize, SquareSize);
            }
        }
    }
}
