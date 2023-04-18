using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class King : Piece
    {
        private bool _check;
        private bool _checkMate;

        public King(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {
            _check = false;
            _checkMate = false;
        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaLigne = Math.Abs(nLigne[0] - nLigne[1]);
            int deltaColonne = Math.Abs(nColonne[0] - nColonne[1]);
            int sommeDelta = Math.Abs(deltaColonne + deltaLigne);

            if (sommeDelta <= 2 && deltaLigne != 2 && deltaColonne != 2)
            {
                if(memPlate[nColonne[1], nLigne[1]] != null)
                {
                    if (_color != memPlate[nColonne[1], nLigne[1]].Color)
                    {
                        movable = true;
                    }
                }             
            }
            return movable;
        }

        public bool IsChecked(int[] nColonne, int[] nLigne, Piece[,] memPlate)  //Verifie l'échec de base (Si le roi est directement attaqué par une pièce)
        {
            if (IsCheckedStraight(nColonne, nLigne, memPlate))
            {
                _check = true;
            }
            else if (IsCheckedDiagonal(nColonne, nLigne, memPlate))
            {
                _check = true;
            }
            else if (IsCheckedByHorse(nColonne, nLigne, memPlate))
            {
                _check = true;
            }
            else
            {
                _check = false;
            }

            return _check;
        }

        private bool IsCheckedStraight(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool obstacle;
            int i;
            int j;

            obstacle = false;
            if (nColonne[0] != 0)
            {
                i = nColonne[0] - 1;
                do
                {
                    if (memPlate[i, nLigne[0]] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, nLigne[0]] is Queen || memPlate[i, nLigne[0]] is Tower)
                        {
                            if (memPlate[i, nLigne[0]].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i--;

                } while (!obstacle || i != 0);
            }

            obstacle = false;
            if (nColonne[0] != 7)
            {
                i = nColonne[0] + 1;
                do
                {
                    if (memPlate[i, nLigne[0]] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, nLigne[0]] is Queen || memPlate[i, nLigne[0]] is Tower)
                        {
                            if (memPlate[i, nLigne[0]].Color != _color)
                            {
                                return true;
                            }                           
                        }
                    }
                    i++;

                } while (!obstacle || i != 7);
            }


            obstacle = false;
            if (nLigne[0] != 0)
            {
                j = nLigne[0] - 1;
                do
                {
                    if (memPlate[nColonne[0], j] != null)
                    {
                        obstacle = true;
                        if (memPlate[nColonne[0], j] is Queen || memPlate[nColonne[0], j] is Tower)
                        {
                            if (memPlate[nColonne[0], j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    j--;
                } while (!obstacle || j != 0);
            }

            obstacle = false;
            if (nLigne[0] != 7)
            {
                j = nLigne[0] + 1;
                do
                {
                    if (memPlate[nColonne[0], j] != null)
                    {
                        obstacle = true;
                        if (memPlate[nColonne[0], j] is Queen || memPlate[nColonne[0], j] is Tower)
                        {
                            if (memPlate[nColonne[0], j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    j++;
                } while (!obstacle || j != 7);
            }

            return false;
        }

        private bool IsCheckedDiagonal(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool obstacle;
            int i;
            int j;

            obstacle = false;
            if(nColonne[0] != 0 && nLigne[0] != 0)
            {
                i = nColonne[0] - 1;
                j = nLigne[0] - 1;
                do
                {
                    if(memPlate[i, j] != null)
                    {
                        obstacle = true;
                        if(memPlate[i, j] is Queen || memPlate[i, j] is Bishop)
                        {
                            if(memPlate[i, j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i--;
                    j--;
                } while (!obstacle && i != 0 || j != 0);
            }

            obstacle = false;
            if (nColonne[0] != 7 && nLigne[0] != 0)
            {
                i = nColonne[0] + 1;
                j = nLigne[0] - 1;
                do
                {
                    if (memPlate[i, j] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, j] is Queen || memPlate[i, j] is Bishop)
                        {
                            if (memPlate[i, j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i++;
                    j--;
                } while (!obstacle && i != 7 || j != 0);
            }

            obstacle = false;
            if (nColonne[0] != 0 && nLigne[0] != 7)
            {
                i = nColonne[0] - 1;
                j = nLigne[0] + 1;
                do
                {
                    if (memPlate[i, j] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, j] is Queen || memPlate[i, j] is Bishop)
                        {
                            if (memPlate[i, j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i--;
                    j++;
                } while (!obstacle && i != 0 || j != 7);
            }

            obstacle = false;
            if (nColonne[0] != 7 && nLigne[0] != 7)
            {
                i = nColonne[0] + 1;
                j = nLigne[0] + 1;
                do
                {
                    if (memPlate[i, j] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, j] is Queen || memPlate[i, j] is Bishop)
                        {
                            if (memPlate[i, j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i++;
                    j++;
                } while (!obstacle && i != 7 || j != 7);
            }

            return false;
        }

        private bool IsCheckedByHorse(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            

            return false;
        }
    }
}
