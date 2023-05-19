using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        private bool _notMove;

        public Pawn(int[] position, string color) : base(position, color)
        {
            this._notMove = true;
        }
        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaColonne = _position[0] - nColonne[1];
            int deltaLigne = _position[1] - nLigne[1];

            if(_color == "black")   //Le cas du pion noir (Il ne peut que descendre)
            {
                if (deltaColonne == -1 && deltaLigne == 0)  //Il fait un coup basique
                {
                    if (memPlate[nColonne[1], nLigne[1]] == null)   //Il ne peut pas y avoir d'obstacle à son arrivée
                    {
                        movable = true;
                    }
                }
                else if(deltaColonne == -2 && deltaLigne == 0)  //Il fait un grand déplacement
                {
                    if(_notMove)    //Ce n'est que à son premier déplacement qu'il peut faire cela
                    {
                        if (memPlate[3, _position[1]] == null && memPlate[2, _position[1]] == null) //Il n'y doit y avoir aucun obstacles sur la route et à son arrivée
                        {
                            movable = true;
                        }
                    }                  
                }
                else if(deltaColonne == -1 && Math.Abs(deltaLigne) == 1)    //Il attaque
                {
                    if(memPlate[nColonne[1], nLigne[1]] != null)    //Il faut qu'il y ai une pièce ennemi pour qu'il puisse attaquer
                    {
                        if (memPlate[nColonne[1], nLigne[1]].Color != _color)   //La pièce doit être à l'ennemi
                        {
                            movable = true;
                        }
                    }                  
                }
            }
            else    //Cas du pion blanc (Il ne peut que aller vers le haut)
            {
                if (deltaColonne == 1 && deltaLigne == 0)
                {
                    if (memPlate[nColonne[1], nLigne[1]] == null)
                    {
                        movable = true;
                    }
                }
                else if (deltaColonne == 2 && deltaLigne == 0)
                {
                    if (_notMove)
                    {
                        if (memPlate[5, _position[1]] == null && memPlate[4, _position[1]] == null)
                        {
                            movable = true;
                        }
                    }
                }
                else if (deltaColonne == 1 && Math.Abs(deltaLigne) == 1)
                {
                    if (memPlate[nColonne[1], nLigne[1]] != null)
                    {
                        if (memPlate[nColonne[1], nLigne[1]].Color != _color)
                        {
                            movable = true;
                        }
                    }
                }
            }

            if (movable)
            {
                _position[0] = nColonne[1];
                _position[1] = nLigne[1];


                _notMove = false;

                Promote();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Promote()
        {
            Promotion promotion = new Promotion();

            if (_color == "black")
            {
                if (_position[0] == 7)
                {
                    promotion.Show();
                }
            }
        }
    }
}
