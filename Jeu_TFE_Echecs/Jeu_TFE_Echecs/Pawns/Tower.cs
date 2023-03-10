using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Tower : Piece
    {
        public Tower(int[] position, string color, string typePïece) : base(position, color, typePïece)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            bool nCSame = false;
            bool nLSame = false;

            if(nColonne[0] == nColonne[1])
            {
                nCSame = true;
            }

            if(nLigne[0] == nLigne[1])
            {
                nLSame = true;
            }

            if(nCSame || nLSame)
            {
                movable = true;

                if(nCSame && nLSame)
                {
                    movable = false;
                }

                if (nCSame)
                {
                    if(nColonne[0] < nColonne[1])
                    {
                        for (int i = nColonne[0]; i < nColonne[1]; i++)
                        {
                            if(memPlate[nColonne[i], nLigne[0]] != null)
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
                else
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
                            if (memPlate[nColonne[0], nLigne[1]] != null)
                            {
                                movable = false;
                            }
                        }
                    }
                }
            }

            return movable;
        }
    }
}
