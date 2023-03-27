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
                movable = true;

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
            }

            int deltaLigne = Math.Abs(nLigne[0] - nLigne[1]);
            int deltaColonne = Math.Abs(nColonne[0] - nColonne[1]);

            if (deltaLigne == deltaColonne)
            {
                movable = true;
            }

            return movable;
        }
    }
}
