using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Bishop : Piece
    {
        public Bishop(int[] position, string color) : base(position, color)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaLigne = _position[1] - nLigne[1];
            int deltaColonne = _position[0] - nColonne[1];

            if (Math.Abs(deltaLigne) == Math.Abs(deltaColonne))
            {
                movable = true;

                int j;
                if (deltaColonne > 0 && deltaLigne < 0) //Déplacement UR (Up-Right)
                {
                    j = _position[1] + 1;
                    for (int i = _position[0] - 1; i > nColonne[1]; i--)
                    {
                        if (memPlate[i, j] != null)
                        {
                            movable = false;
                        }
                        j++;
                    }
                }
                else if (deltaColonne > 0 && deltaLigne > 0) //Déplacement UL (Up-Left)
                {
                    j = _position[1] - 1;
                    for (int i = _position[0] - 1; i > nColonne[1]; i--)
                    {
                        if (memPlate[i, j] != null)
                        {
                            movable = false;
                        }
                        j--;
                    }
                }
                else if (deltaColonne < 0 && deltaLigne > 0) // Déplacement DL (Down-Left)
                {
                    j = _position[1] - 1;
                    for (int i = _position[0] + 1; i < nColonne[1]; i++)
                    {
                        if (memPlate[i, j] != null)
                        {
                            movable = false;
                        }
                        j--;
                    }
                }
                else if (deltaColonne < 0 && deltaLigne < 0) // Déplacement DR (Down-Right)
                {
                    j = _position[1] + 1;
                    for (int i = _position[0] + 1; i < nColonne[1]; i++)
                    {
                        if (memPlate[i, j] != null)
                        {
                            movable = false;
                        }
                        j++;
                    }
                }
            }

            if (memPlate[nColonne[1], nLigne[1]] != null)
            {
                if (_color == memPlate[nColonne[1], nLigne[1]].Color)
                {
                    movable = false;
                }
            }

            if (movable)
            {
                _position[0] = nColonne[1];
                _position[1] = nLigne[1];

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
