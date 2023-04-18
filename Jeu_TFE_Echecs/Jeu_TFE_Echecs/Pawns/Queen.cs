using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Queen : Piece
    {
        public Queen(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            bool nCSame = false;
            bool nLSame = false;

            if (nColonne[0] == nColonne[1])
            {
                nCSame = true;
            }

            if (nLigne[0] == nLigne[1])
            {
                nLSame = true;
            }

            if (nCSame || nLSame)
            {
                movable = StraightMoving(nColonne, nLigne, memPlate, nCSame, nLSame);
            }
            else
            {
                int deltaLigne = nLigne[0] - nLigne[1];
                int deltaColonne = nColonne[0] - nColonne[1];

                if (Math.Abs(deltaLigne) == Math.Abs(deltaColonne))
                {
                    movable = DiagonalMoving(nColonne, nLigne, memPlate, deltaLigne, deltaColonne);
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

        private bool StraightMoving(int[] nColonne, int[] nLigne, Piece[,] memPlate, bool nCSame, bool nLSame)
        {
            bool movable = true;

            if (nCSame)
            {
                if (nLigne[0] > nLigne[1])
                {
                    for (int i = nLigne[0] - 1; i > nLigne[1]; i--)
                    {
                        if (memPlate[nColonne[0], i] != null)
                        {
                            movable = false;
                        }
                    }
                }
                else
                {
                    for (int i = nLigne[0] + 1; i < nLigne[1]; i++)
                    {
                        if (memPlate[nColonne[0], i] != null)
                        {
                            movable = false;
                        }
                    }
                }
            }
            else
            {
                if (nColonne[0] > nColonne[1])
                {
                    for (int i = nColonne[0] - 1; i > nColonne[1]; i--)
                    {
                        if (memPlate[i, nLigne[0]] != null)
                        {
                            movable = false;
                        }
                    }
                }
                else
                {
                    for (int i = nColonne[0] + 1; i < nColonne[1]; i++)
                    {
                        if (memPlate[i, nLigne[0]] != null)
                        {
                            movable = false;
                        }
                    }
                }
            }

            return movable;
        }

        private bool DiagonalMoving(int[] nColonne, int[] nLigne, Piece[,] memPlate, int deltaLigne, int deltaColonne)
        {
            bool movable = true;

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

            return movable;
        }
    }
}
