using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Pawn : Piece
    {
        private bool _passant;
        private bool _notMove;

        public Pawn(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {
            this._passant = false;
            this._notMove = true;
        }
        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaColonne = nColonne[0] - nColonne[1];
            int deltaLigne = nLigne[0] - nLigne[1];
         
            if (Color == "black") //Cas des pions noir
            {
                if (_notMove) //Il ne s'est pas encore déplacé il peut donc avancer de 2 cases si il le veut
                {
                    if ((deltaColonne == -2 || deltaColonne == -1 && nLigne[0] == nLigne[1]) || (Math.Abs(deltaLigne) == 1 && deltaColonne == -1)) //Condition de déplacement (Il ne peut avancer que en 100% verticale vers le bas de 1 ou 2 cases ou d'attaquer)
                    {
                        if (deltaColonne == -2) //Il avance de 2 cases d'un coup
                        {
                            if (memPlate[2, nLigne[0]] == null) //Vérifie si il y a un obstacle entre 
                            {
                                movable = true; //Il peut se déplacer
                            }
                        }
                        else if (Math.Abs(deltaLigne) == 1 && deltaColonne == -1) //Il prend
                        {
                            if (memPlate[nColonne[1], nLigne[1]] != null) //La case qu'il prend à une pièce
                            {
                                if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color) //Cette pièce ne doit pas être de la même couleur que le pion se déplaçant
                                {
                                    movable = true; //Il peut se dépalcer
                                }
                            }
                        }
                       
                        _notMove = false; // Il s'est déplacé pour la première fois
                    }
                }
                else //Il s'est déjà déplacé une fois
                {
                    if ((deltaColonne == -1 && nLigne[0] == nLigne[1]) || (Math.Abs(deltaLigne) == 1 && deltaColonne == -1)) //Il ne peut se deplacer que d'une case dans sa direction ou prendre une pièce en diagonale
                    {
                        if (Math.Abs(deltaLigne) == 1 && deltaColonne == -1) //Il a décidé de prendre
                        {
                            if (memPlate[nColonne[1], nLigne[1]] != null) //La case qu'il attaque à une pièce
                            {
                                if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color) //Cette pièce ne doit pas être de la même couleur que le pion se déplaçant
                                {
                                    movable = true; //Il peut se dépalcer
                                }
                            }
                        }
                        else if (deltaColonne == -1 && nLigne[0] == nLigne[1]) //Il a choisit de se déplacer
                        {
                            if (memPlate[nColonne[1], nLigne[1]] == null) //La case devant lui est vide
                            {
                                movable = true; //Il peut se déplacer
                            }
                        }
                    }
                }
            }
            else //Cas du pion blanc
            {
                if (_notMove)//Il ne s'est pas encore déplacé il peut donc avancer de 2 cases si il le veut
                {
                    if ((deltaColonne == 2 || deltaColonne == 1 && nLigne[0] == nLigne[1]) || (Math.Abs(deltaLigne) == 1 && deltaColonne == 1)) //Condition de déplacement (Il ne peut avancer que en 100% verticale vers le haut de 1 ou 2 cases ou d'attaquer)
                    {
                        if (deltaColonne == 2) //Il se déplace de deux cases
                        {
                            if (memPlate[5, nLigne[0]] == null) //Il n'y a pas d'obstacles entre le pion et sa destination
                            {
                                movable = true; //Il peut donc se déplacer
                            }
                        }
                        else if(Math.Abs(deltaLigne) == 1 && deltaColonne == 1) //Il prend une pièce
                        {
                            if (memPlate[nColonne[1], nLigne[1]] != null) //La case qu'il prend n'est pas vide
                            {
                                if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color) //La pièce prise doit être de couleur différente que le pion
                                {
                                    movable = true; //Il peut se déplacer
                                }
                            }
                        }

                        _notMove = false; //Il s'est déplacé pour la première fois
                    }
                }
                else
                {
                    if ((deltaColonne == 1 && nLigne[0] == nLigne[1]) || (Math.Abs(deltaLigne) == 1 && deltaColonne == 1))
                    {
                        if(Math.Abs(deltaLigne) == 1 && deltaColonne == 1)
                        {
                            if (memPlate[nColonne[1], nLigne[1]] != null)
                            {
                                if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color)
                                {
                                    movable = true;
                                }
                            }
                        }                   
                        else if(deltaColonne == 1 && nLigne[0] == nLigne[1])
                        {
                            if(memPlate[nColonne[1], nLigne[1]] == null)
                            {
                                movable = true;
                            }                          
                        }            
                    }
                }
            }

            if (memPlate[nColonne[1], nLigne[1]] != null)
            {
                if (memPlate[nColonne[0], nLigne[0]].Color == memPlate[nColonne[1], nLigne[1]].Color)
                {
                    movable = false;
                }
            }
            return movable;
        }
    }
}
