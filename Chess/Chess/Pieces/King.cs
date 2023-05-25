﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class King : Piece
    {
        private bool _check;
        private bool _checkMate;
        private int _rocMove;

        public King(int[] position, string color) : base(position, color)
        {
            _check = false;
            _checkMate = false;
            _roc = true;
            _rocMove = 0;
        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            if (BasicMove(nColonne, nLigne, memPlate) || Roc(nColonne, nLigne, memPlate))
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

        private bool BasicMove(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaLigne = Math.Abs(nLigne[0] - nLigne[1]);
            int deltaColonne = Math.Abs(nColonne[0] - nColonne[1]);
            int sommeDelta = Math.Abs(deltaColonne + deltaLigne);

            if (sommeDelta <= 2 && deltaLigne != 2 && deltaColonne != 2)
            {
                movable = true;
                if (memPlate[nColonne[1], nLigne[1]] != null)
                {
                    if (_color == memPlate[nColonne[1], nLigne[1]].Color)
                    {
                        movable = false;
                    }
                }
            }

            return movable;
        }

        private bool Roc(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            if (_roc)
            {
                if(_color == "white")
                {
                    if (nColonne[1] == 7 && nLigne[1] == 0)
                    {
                        if (memPlate[7,0] is Tower)
                        {
                            if (memPlate[7, 0].Roc)
                            {
                                if (memPlate[0, 7].Color == _color)
                                {
                                    if (memPlate[7, 1] is null && memPlate[7, 2] is null && memPlate[7, 3] is null)
                                    {
                                        _rocMove = 1;
                                        return true;
                                    }
                                }                               
                            }
                        }
                    }
                    else if (nColonne[1] == 7 && nLigne[1] == 7)
                    {
                        if (memPlate[7, 7] is Tower)
                        {
                            if (memPlate[7, 7].Roc)
                            {
                                if (memPlate[0, 7].Color == _color)
                                {
                                    if (memPlate[7, 5] is null && memPlate[7, 6] is null)
                                    {
                                        _rocMove = 2;
                                        return true;
                                    }
                                }                               
                            }
                        }
                    }
                }
                else
                {
                    if (nColonne[1] == 0 && nLigne[1] == 0)
                    {
                        if (memPlate[0, 0] is Tower)
                        {
                            if (memPlate[0, 0].Roc)
                            {
                                if (memPlate[0, 7].Color == _color)
                                {
                                    if (memPlate[0, 1] is null && memPlate[0, 2] is null && memPlate[0, 3] is null)
                                    {
                                        _rocMove = 3;
                                        return true;
                                    }
                                }                               
                            }
                        }
                    }
                    else if (nColonne[1] == 0 && nLigne[1] == 7)
                    {
                        if (memPlate[0, 7] is Tower)
                        {
                            
                            if (memPlate[0, 7].Roc)
                            {
                                if (memPlate[0, 7].Color == _color)
                                {
                                    if (memPlate[0, 5] is null && memPlate[0, 6] is null)
                                    {
                                        _rocMove = 4;
                                        return true;
                                    }
                                }                               
                            }
                        }
                    }
                }
            }

            return false;

        }

        public override bool IsChecked(Piece[,] memPlate)  //Verifie l'échec de base (Si le roi est directement attaqué par une pièce)
        {
            if (IsCheckedStraight(memPlate))
            {
                _check = true;
            }
            else if (IsCheckedDiagonal(memPlate))
            {
                _check = true;
            }
            else if (IsCheckedByHorse(memPlate))
            {
                _check = true;
            }
            else if(IsCheckedByPawn(memPlate))
            {
                _check = true;
            }
            else
            {
                _check = false;
            }

            return _check;
        }

        private bool IsCheckedStraight(Piece[,] memPlate)
        {
            bool obstacle;
            int i;
            int j;

            obstacle = false;
            if (_position[0] != 0)
            {
                i = _position[0] - 1;
                do
                {
                    if (memPlate[i, _position[1]] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, _position[1]] is Queen || memPlate[i, _position[1]] is Tower)
                        {
                            if (memPlate[i, _position[1]].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i--;

                } while (!obstacle && i >= 0);
            }

            obstacle = false;
            if (_position[0] != 7)
            {
                i = _position[0] + 1;
                do
                {
                    if (memPlate[i, _position[1]] != null)
                    {
                        obstacle = true;
                        if (memPlate[i, _position[1]] is Queen || memPlate[i, _position[1]] is Tower)
                        {
                            if (memPlate[i, _position[1]].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    i++;

                } while (!obstacle && i <= 7);
            }


            obstacle = false;
            if (_position[1] != 0)
            {
                j = _position[1] - 1;
                do
                {
                    if (memPlate[_position[0], j] != null)
                    {
                        obstacle = true;
                        if (memPlate[_position[0], j] is Queen || memPlate[_position[0], j] is Tower)
                        {
                            if (memPlate[_position[0], j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    j--;
                } while (!obstacle && j >= 0);
            }

            obstacle = false;
            if (_position[1] != 7)
            {
                j = _position[1] + 1;
                do
                {
                    if (memPlate[_position[0], j] != null)
                    {
                        obstacle = true;
                        if (memPlate[_position[0], j] is Queen || memPlate[_position[0], j] is Tower)
                        {
                            if (memPlate[_position[0], j].Color != _color)
                            {
                                return true;
                            }
                        }
                    }
                    j++;
                } while (!obstacle && j <= 7);
            }

            return false;
        }

        private bool IsCheckedDiagonal(Piece[,] memPlate)
        {
            bool obstacle;
            int i;
            int j;

            obstacle = false;
            if (_position[0] != 0 && _position[1] != 0)
            {
                i = _position[0] - 1;
                j = _position[1] - 1;
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
                    j--;
                } while (!obstacle && i >= 0 && j >= 0);
            }

            obstacle = false;
            if (_position[0] != 7 && _position[1] != 0)
            {
                i = _position[0] + 1;
                j = _position[1] - 1;
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
                } while (!obstacle && i <= 7 && j >= 0);
            }

            obstacle = false;
            if (_position[0] != 0 && _position[1] != 7)
            {
                i = _position[0] - 1;
                j = _position[1] + 1;
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
                } while (!obstacle && i >= 0 && j <= 7);
            }

            obstacle = false;
            if (_position[0] != 7 && _position[1] != 7)
            {
                i = _position[0] + 1;
                j = _position[1] + 1;
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
                } while (!obstacle && i <= 7 && j <= 7);
            }

            return false;
        }

        private bool IsCheckedByHorse(Piece[,] memPlate)
        {

            //En haut proche
            if (_position[0] - 1 >= 0)
            {
                //Gauche Loin
                if (_position[1] - 2 >= 0) //Première emplacement
                {
                    if (memPlate[_position[0] - 1, _position[1] - 2] != null)    //La case n'est pas vide
                    {
                        if (memPlate[_position[0] - 1, _position[1] - 2] is Horse) //La case est comblée par un cavalier
                        {
                            if (memPlate[_position[0] - 1, _position[1] - 2].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                            {
                                return true; //Le roi est en échec
                            }
                        }
                    }
                }

                //Droite Loin
                if (_position[1] + 2 <= 7) //Deuxième emplacement
                {
                    if (memPlate[_position[0] - 1, _position[1] + 2] != null)    //La case n'est pas vide
                    {
                        if (memPlate[_position[0] - 1, _position[1] + 2] is Horse) //La case est comblée par un cavalier
                        {
                            if (memPlate[_position[0] - 1, _position[1] + 2].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                            {
                                return true; //Le roi est en échec
                            }
                        }
                    }
                }


                //En haut loin
                if (_position[0] - 2 >= 0)
                {
                    //Gauche Proche
                    if (_position[1] - 1 >= 0) //Troisème emplacement
                    {
                        if (memPlate[_position[0] - 2, _position[1] - 1] != null)    //La case n'est pas vide
                        {
                            if (memPlate[_position[0] - 2, _position[1] - 1] is Horse) //La case est comblée par un cavalier
                            {
                                if (memPlate[_position[0] - 2, _position[1] - 1].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                                {
                                    return true; //Le roi est en échec
                                }
                            }
                        }
                    }

                    //Droite proche
                    if (_position[1] + 1 <= 7) //Quatrième emplacement
                    {
                        if (memPlate[_position[0] - 2, _position[1] + 1] != null)    //La case n'est pas vide
                        {
                            if (memPlate[_position[0] - 2, _position[1] + 1] is Horse) //La case est comblée par un cavalier
                            {
                                if (memPlate[_position[0] - 2, _position[1] + 1].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                                {
                                    return true; //Le roi est en échec
                                }
                            }
                        }
                    }
                }
            }




            //En dessous
            if (_position[0] + 1 <= 7)
            {
                //Loin gauche
                if (_position[1] - 2 >= 0) //Cinquième emplacement
                {
                    if (memPlate[_position[0] + 1, _position[1] - 2] != null)    //La case n'est pas vide
                    {
                        if (memPlate[_position[0] + 1, _position[1] - 2] is Horse) //La case est comblée par un cavalier
                        {
                            if (memPlate[_position[0] + 1, _position[1] - 2].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                            {
                                return true; //Le roi est en échec
                            }
                        }
                    }
                }

                //Loin Droite
                if (_position[1] + 2 <= 7) //Sixième emplacement
                {
                    if (memPlate[_position[0] + 1, _position[1] + 2] != null)    //La case n'est pas vide
                    {
                        if (memPlate[_position[0] + 1, _position[1] + 2] is Horse) //La case est comblée par un cavalier
                        {
                            if (memPlate[_position[0] + 1, _position[1] + 2].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                            {
                                return true; //Le roi est en échec
                            }
                        }
                    }
                }

                //En haut loin
                if (_position[0] + 2 <= 7)
                {
                    //Proche gauche
                    if (_position[1] - 1 >= 0) //Septième emplacement
                    {
                        if (memPlate[_position[0] + 2, _position[1] - 1] != null)    //La case n'est pas vide
                        {
                            if (memPlate[_position[0] + 2, _position[1] - 1] is Horse) //La case est comblée par un cavalier
                            {
                                if (memPlate[_position[0] + 2, _position[1] - 1].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                                {
                                    return true; //Le roi est en échec
                                }
                            }
                        }
                    }

                    //Proche Droite
                    if (_position[1] + 1 <= 7) //Huitème emplacement
                    {
                        if (memPlate[_position[0] + 2, _position[1] + 1] != null)    //La case n'est pas vide
                        {
                            if (memPlate[_position[0] + 2, _position[1] + 1] is Horse) //La case est comblée par un cavalier
                            {
                                if (memPlate[_position[0] + 2, _position[1] + 1].Color != _color) //Le cavalier n'est pas de la même couleur que le roi
                                {
                                    return true; //Le roi est en échec
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool IsCheckedByPawn(Piece[,] memPlate)
        {
            if (_color == "white")
            {
                if (_position[0] <= 2)
                {
                    if(_position[1] <= 6)
                    {
                        if (memPlate[_position[0] - 1, _position[1] + 1] != null)
                        {
                            if (memPlate[_position[0] - 1, _position[1] + 1] is Pawn)
                            {
                                if (memPlate[_position[0] - 1, _position[1] + 1].Color == "black")
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    
                    if(_position[1] >= 1)
                    {
                        if (memPlate[_position[0] - 1, _position[1] - 1] != null)
                        {
                            if (memPlate[_position[0] - 1, _position[1] - 1] is Pawn)
                            {
                                if (memPlate[_position[0] - 1, _position[1] - 1].Color == "black")
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                if (_position[0] <= 5)
                {
                    if (_position[1] <= 6)
                    {
                        if (memPlate[_position[0] + 1, _position[1] + 1] != null)
                        {
                            if (memPlate[_position[0] + 1, _position[1] + 1] is Pawn)
                            {
                                if (memPlate[_position[0] + 1, _position[1] + 1].Color == "white")
                                {
                                    return true;
                                }
                            }
                        }
                    }

                    if (_position[1] >= 1)
                    {
                        if (memPlate[_position[0] + 1, _position[1] - 1] != null)
                        {
                            if (memPlate[_position[0] + 1, _position[1] - 1] is Pawn)
                            {
                                if (memPlate[_position[0] + 1, _position[1] - 1].Color == "white")
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }           
            }
            return false;

        }

        public int RocMove
        {
            get { return _rocMove; }
        }

    }
}