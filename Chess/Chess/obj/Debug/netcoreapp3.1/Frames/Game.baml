   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chess.FramesChess.Frames  5          Chess.Frames.Game   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Chess.Frames     5        N� Title$
  Game��5	      .��5      � -   5         �Name$ 
gameScreen��5      .+�5   
   � -   5        $ informations��5      $��0��6   
����� � � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��2* �6#   �� 5      $��2* �6#   �� 5      $��2* �6#   �� 5      $��2* �6#   .+�5      �� -   5         ��Name$
 tour��5      $��Trait aux blancs��6&   $��Center=�6>    �� Padding$ 0, 10, 0, 0q�6[   $��Center=�6q   
�������
���   �$
��Bold"�6�   $��40��6�   �� 5      -   5        $ check��5      $��1��6'   $��Center=�67   $ 0, 10, 0, 0q�6T   $��Center=�6j   
�������
���   �$
��Bold"�6�   $��40��6�   6�   �� 5      -   5        $ afficheTime��5      $��2��6-   $��Center=�6=   $��Center=�6Z   
���  ��$�� ��6�   �� 5      $��3��6   .+�5      �� $��10(�6   Pions prit par les noirs :6F   �� 5      -   5        $ prisesNoirs��5      63   5      �� 5       $��4��6   .+�5!      �� $��10(�6   Pions prit par les blancs :6G   �� 5"      -   5        $ prisesBlanches��5"      66   5#      5$       � RowDefinitions 5&   
   �� 5'      $��1* �6   �� 5(      $��8* �6   5*      5+      