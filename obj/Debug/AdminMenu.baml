   M S B A M L   `   `   `  ����M  Iguichetauto_projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:guichetauto_projetguichetauto_projet  5   	   "    guichetauto_projet.AdminMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:guichetauto_projet     5   	     � Title$  
Menu Admin��5      $	��500��6    $	��660��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � ���	#FF005DA5 � ColumnDefinitions 5
   
   �� 5      $��20 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��10 �6   6*   �� 5      $��80 �6   6*   �� 5      $��40 �6   6*   �� 5      $��60 �6   6*   �� 5      $��80 �6   6*   .+�5   
   �� -   5         ��Name$ lblInfo��5      $��Opérations��6!   ���	#FF005DA5$��25(�6M   $��Center=�6[   $��Center=�6   
�������$
��Bold"�6�   $��Microsoft JhengHei UI)�6�   $��0��6�   $��1��6�   $��3��6  $��110,0,100,0q�6  �� 5   
   -   5        $ lblInfo2��5      $&�� Opérations sur tout les comptes��6"   ���	#FF005DA5$��12(�6c   $��Center=�6q   $��Center=�6�   
�������$��30��6�   $
��Bold"�6�   $��Microsoft JhengHei UI)�6�   $��0��6  $��5��6  $��	0,40,0,10q�6(  �� 5   
   -   5         ��Name$ 	btnClient��5      $��Clients��6$   $��1��66   $��1��6C   $��30(�6S   ���	#FF00CAFF
�������$
��Bold"�6�   $��Microsoft JhengHei UI)�6�   6�   �� 5    
   -   5        $ 	btnCompte��5       $��Comptes��6$   $��1��66   $��3��6C   $��30(�6S   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5!   
   -   5        $ 
btnGuichet��5!      $��Guichet��6%   $��3��67   $��3��6D   $��30(�6T   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5"   
   -   5        $ 
btnInteret��5"      $��Intérêt Épargne (1%)��6%   $��3��6D   $��5��6Q   $��15(�6a   $��50��6o   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5#   
   -   5        $ btnPrelever��5#      $��	Prélever��6&   $��3��69   $��1��6F   $��30(�6V   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5$   
   -   5        $ btnMarge��5$      $��Augmenter Marge (5%)��6#   $��1��6B   $��50��6O   $��5��6[   $��15(�6k   ���	#FF00CAFF
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   �� 5%   
   -	   5        $ btnTransaction��5%      $��Afficher les transactions��6)   $��4��6M   $��25(�6Z   $��5��6h   $��160,30,160,10q�6|   $��1��6�   $��2��6�   
����������	#FF1164D2$	��300��6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6  6  �� 5&   
   -
   5        $ btnQuit��5&      $��Quitter��6"   $��6��64   $��3��6A   $��30(�6Q   $	��120��6_   $��40,10,40,10q�6k   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   6�   5(      5)      