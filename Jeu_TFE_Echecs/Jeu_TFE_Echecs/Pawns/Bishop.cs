using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Bishop : Piece
    {
        public Bishop(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaLigne = nLigne[0] - nLigne[1];
            int deltaColonne = nColonne[0] - nColonne[1];

            if (Math.Abs(deltaLigne) == Math.Abs(deltaColonne))
            {
                movable = true;

                int j;
                if (deltaColonne > 0 && deltaLigne < 0) //Déplacement UR (Up-Right)
                {
                    j = nLigne[0] + 1;
                    for (int i = nColonne[0] - 1; i > nColonne[1]; i--)
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
                    j = nLigne[0] - 1;
                    for (int i = nColonne[0] - 1; i > nColonne[1]; i--)
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
                    j = nLigne[0] - 1;
                    for (int i = nColonne[0] + 1; i < nColonne[1]; i++)
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
                    j = nLigne[0] + 1;
                    for (int i = nColonne[0] + 1; i < nColonne[1]; i++)
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

            return movable;
        }
    }
}
