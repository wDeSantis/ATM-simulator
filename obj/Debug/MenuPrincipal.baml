   M S B A M L   `   `   `  ����M  Iguichetauto_projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:guichetauto_projetguichetauto_projet  5   	   &     guichetauto_projet.MenuPrincipal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:guichetauto_projet     5   	   -   5          �Name$  MenuPrincipal1��5   	    � Title$
 Menu��5   	   $	��500��6   $	��660��6#    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�6E   .��5	      � ���	#FF005DA5 � ColumnDefinitions 5
   
   �� 5      $��20 �6   6,   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��10 �6   6*   �� 5      $��80 �6   6*   �� 5      $��40 �6   6*   �� 5      $��60 �6   6*   �� 5      $��80 �6   6*   .+�5   
   �� -   5         ��Name$ lblBienvenue��5      $��0��6&   $��1��63   $��	Bienvenue��6C   $��15(�6W   $��40��6e   $	��120��6q   $
��Left=�6}   $��Bottom=�6�   $��Bottom=�6�   ���	#FF00CAFF$��Miriam Libre)�6�   $
��Bold"�6  $��0,0,0,75q�6  $��2��6*  �� 5   
   -   5        $ txtNomClient��5      $��1��6&   $��1��63   $�� ��6C   $��15(�6N   $��70��6\   $	��Top=�6h   $��0 10 0 0q�6�   
�������$��Miriam Libre)�6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ btnDepot��5      $��Dépot��6#   $��1��63   $��2��6@   $��30(�6P   ���	#FF00CAFF
�������$
��Bold"�6�   $��Microsoft JhengHei UI)�6�   6�   �� 5    
   -   5        $ 
btnRetrait��5       $��Retrait��6%   $��1��67   $��4��6D   $��30(�6T   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5!   
   -   5        $ btnTransfert��5!      $��	Transfert��6'   $��3��6;   $��2��6H   $��30(�6X   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5"   
   -   5        $ btnPaiement��5"      $��Paiement��6&   $��3��69   $��4��6F   $��30(�6V   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5#   
   -   5        $ 	btnSoldes��5#      $��Afficher les soldes��6$   $��4��6B   $��25(�6O   $��3��6]   $��80,20,80,20q�6q   $��2��6�   $��2��6�   
����������	#FF1164D2$	��250��6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6   6  �� 5$   
   -	   5        $ btnQuit��5$      $��Quitter��6"   $��6��64   $��2��6A   $��30(�6Q   $	��120��6_   $��145,10,145,10q�6k   $��3��6�   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   5&      5'      