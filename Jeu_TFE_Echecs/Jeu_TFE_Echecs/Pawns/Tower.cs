using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Tower : Piece
    {
        private bool _roc;
        public Tower(int[] position, string color) : base(position, color)
        {
            _roc = true;
        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            bool nCSame = false;
            bool nLSame = false;

            if(_position[0] == nColonne[1])
            {
                nCSame = true;
            }

            if(_position[1] == nLigne[1])
            {
                nLSame = true;
            }

            if (nCSame || nLSame)
            {
                movable = true;

                if (nCSame)
                {
                    if(_position[1] > nLigne[1])
                    {
                        for (int i = _position[1] - 1; i > nLigne[1]; i--)
                        {
                            if(memPlate[_position[0], i] != null)
                            {
                                movable = false;
                            }
                        }                     
                    }
                    else
                    {
                        for (int i = _position[1] + 1; i < nLigne[1]; i++)
                        {
                            if (memPlate[_position[0], i] != null)
                            {
                                movable = false;
                            }
                        }
                    }
                }
                else
                {
                    if (_position[0] > nColonne[1])
                    {
                        for (int i = _position[0] - 1; i > nColonne[1]; i--)
                        {
                            if (memPlate[i, _position[1]] != null)
                            {
                                movable = false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = _position[0] + 1; i < nColonne[1]; i++)
                        {
                            if (memPlate[i, _position[1]] != null)
                            {
                                movable = false;
                            }
                        }
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
                _roc = false;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
