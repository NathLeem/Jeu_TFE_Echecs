using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Queen : Piece
    {
        public Queen(int[] position, string color, string typePiece) : base(position, color, typePiece)
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

                if (nCSame && nLSame)
                {
                    movable = false;
                }
                /*else
                {
                    if (nCSame)
                    {
                        if (nLigne[0] < nLigne[1])
                        {
                            for (int i = nLigne[0]; i < nLigne[1]; i++)
                            {
                                if (memPlate[nColonne[0], nLigne[i]] != null)
                                {
                                    movable = false;
                                }
                            }
                        }
                        else
                        {
                            for (int i = nLigne[1]; i > nLigne[0]; i--)
                            {
                                if (memPlate[nColonne[0], nLigne[i]] != null)
                                {
                                    movable = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (nColonne[0] < nColonne[1])
                        {
                            for (int i = nColonne[0]; i < nColonne[1]; i++)
                            {
                                if (memPlate[nColonne[i], nLigne[0]] != null)
                                {
                                    movable = false;
                                }
                            }
                        }
                        else
                        {
                            for (int i = nColonne[1]; i > nColonne[0]; i--)
                            {
                                if (memPlate[nColonne[i], nLigne[0]] != null)
                                {
                                    movable = false;
                                }
                            }
                        }
                    }
                }

                if (memPlate[nColonne[1], nLigne[1]].Color == this.Color)
                {
                    movable = false;
                }*/

               
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
