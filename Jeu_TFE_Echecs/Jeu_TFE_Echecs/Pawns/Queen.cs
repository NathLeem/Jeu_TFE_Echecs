using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Queen : Piece //Classe de la Reine, fille de la classe Pièce
    {
        public Queen(int[] position, string color) : base(position, color)  //Constructeur
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)    //Mouvement de la reine
        {
            bool movable = false;   //On part du principe qu'elle ne peut pas se déplacer   

            bool nCSame = false;    //Détecte si les colonnes sont les mêmes
            bool nLSame = false;    //Détecte si les lignes sont les mêmes

            if (_position[0] == nColonne[1])
            {
                nCSame = true;
            }

            if (_position[1] == nLigne[1])
            {
                nLSame = true;
            }

            if (nCSame || nLSame)   //Si un des deux est vrai : il s'agit d'un déplacement linéaire comme la tour
            {
                movable = StraightMoving(nColonne, nLigne, memPlate, nCSame, nLSame);   //Appel de la fonction du déplacement linéaire
            }
            else    
            {
                int deltaLigne = _position[1] - nLigne[1];         //Calcule la différence entre la première coordonnée y et la deuxième
                int deltaColonne = _position[0] - nColonne[1];   //Calcule la différence entre la première coordonnée x et la deuxième

                if (Math.Abs(deltaLigne) == Math.Abs(deltaColonne)) //Si c'est vrai : il s'agit d'un déplacement de type diagonale, comme celui du fou
                {
                    movable = DiagonalMoving(nColonne, nLigne, memPlate, deltaLigne, deltaColonne); //Appel de la fonction du déplacement en diagonales
                }
            }

            if (memPlate[nColonne[1], nLigne[1]] != null)   //On vérifie si la case finale n'est pas vide
            {
                if (_color == memPlate[nColonne[1], nLigne[1]].Color)   //On vérifie la couleur de la pièce sur la case finale
                {
                    movable = false;    //Elles sont de la même couleur, le déplacement n'est par conséquent pas possible
                }
            }

            if (movable)    //Est-ce que mon déplacement est autorisé?
            {
                _position[0] = nColonne[1]; //Enregistrement de la nouvelle coordonnée x
                _position[1] = nLigne[1];   //Enregistrement de la nouvelle coordonnée y

                return true;    //Envoie vrai
            }
            else
            {
                return false;   //Envoie faux
            }
        }

        private bool StraightMoving(int[] nColonne, int[] nLigne, Piece[,] memPlate, bool nCSame, bool nLSame)  //Fonction de la tour. On vérifie si il n'y a aucun obstacle entre la pièce qui se déplace et sa destination
        {
            if (nCSame) //Déplacement 100% horizontal
            {
                if (_position[1] > nLigne[1])   //Vers la gauche
                {
                    for (int i = _position[1] - 1; i > nLigne[1]; i--)
                    {
                        if (memPlate[_position[0], i] != null)
                        {
                            return false;   //Obstacle détecté : déplacement interdit
                        }
                    }
                }
                else    //Vers la droite
                {
                    for (int i = _position[1] + 1; i < nLigne[1]; i++)
                    {
                        if (memPlate[_position[0], i] != null)
                        {
                             return false;   //Obstacle détecté : déplacement interdit
                        }
                    }
                }
            }
            else    //Déplacement 100% vertical
            { 
                if (_position[0] > nColonne[1])
                {
                    for (int i = _position[0] - 1; i > nColonne[1]; i--)
                    {
                        if (memPlate[i, _position[1]] != null)
                        {
                            return false;    //Obstacle détecté : déplacement interdit
                        }
                    }
                }
                else
                {
                    for (int i = _position[0] + 1; i < nColonne[1]; i++)
                    {
                        if (memPlate[i, _position[1]] != null)
                        {
                            return false;    //Obstacle détecté : déplacement interdit
                        }
                    }
                }
            }

            return true;    //Aucun obstacle détecté : déplacement autorisé

        }

        private bool DiagonalMoving(int[] nColonne, int[] nLigne, Piece[,] memPlate, int deltaLigne, int deltaColonne)  //Fonction du fou. On vérifie si il n'y a aucun obstacle entre la pièce qui se déplace et sa destination
        {
            int j;
            if (deltaColonne > 0 && deltaLigne < 0) //Déplacement UR (Up-Right)
            {
                j = _position[1] + 1;
                for (int i = _position[0] - 1; i > nColonne[1]; i--)
                {
                    if (memPlate[i, j] != null)
                    {
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
                    }
                    j++;
                }
            }

            return true; 
        }
    }
}
