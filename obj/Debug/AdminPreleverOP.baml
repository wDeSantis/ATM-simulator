   M S B A M L   `   `   `  ����M  Iguichetauto_projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:guichetauto_projetguichetauto_projet  5   	   (    "guichetauto_projet.AdminPreleverOP   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:guichetauto_projet     5   	     � Title$  Dépôt Chèque��5      $	��500��6"   $	��660��6/    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   .��5	      � ���	#FF005DA5 � ColumnDefinitions 5
   
   �� 5      $��20 �6   6,   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��10 �6   6*   �� 5      $��80 �6   6*   �� 5      $��40 �6   6*   �� 5      $��60 �6   6*   �� 5      $��80 �6   6*   .+�5   
   �� -   5         ��Name$ lblInfo��5      $��1��6!   $4��.Prélever un montant d'un compte hypothécaire��61   $��25(�6h   
�������$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $	��600��6�   $��50��6�   $��
10,20,0,10q�6�   $��4��6�   �� 5   
   -   5        $ lblDollarSign��5      $��2��6'   $��3��67   $��$��6D   $��35(�6P   
�������$��Microsoft JhengHei UI)�6q   $
��Bold"�6�   $��30��6�   $��50��6�   $��190,10,190,20q�6�   $��3��6�   �� 5   
   -   5        $ 
lblCodeCli��5      $��1��6$   $��1��64   $��Code Client :��6A   
�������$��Microsoft JhengHei UI)�6m   $
��Bold"�6�   $��25(�6�   $��50��6�   $
��Left=�6�   $��
29,10,0,20q�6�    J� RenderTransformOrigin$ 0.569,2.554&�6�   $	��171��6  �� 5    
   -   5         ��Name$ 
txtCodeCli��5       $��2��6&    �� 	MaxLength$ 10��66   $��1��6E   
�������$��Microsoft JhengHei UI)�6f   $
��Bold"�6�   $��25(�6�   ���	#FF00CAFF$��Center=�6�   $��Center=�6�   $��Center=�6  $	��180��6#  $��50��6/  $��	0,10,0,20q�6i  �� 5!   
   -   5        $ 
lblMontant��5!      $��1��6$   $��3��64   $��	Montant :��6A   
�������$��Microsoft JhengHei UI)�6i   $
��Bold"�6�   $��25(�6�   $��50��6�   $
��Left=�6�   $��
62,10,0,20q�6�   $ 0.569,2.554&�6�   �� 5"   
   -   5        $ 
txtMontant��5"      $��2��6&   $��3��66   
�������$��Microsoft JhengHei UI)�6W   $
��Bold"�6z   $��25(�6�   ���	#FF00CAFF$��Center=�6�   $��Center=�6�   $��Center=�6�   $	��180��6  $��50��6   $��	0,10,0,20q�6[  �� 5#   
   -   5        	 ��Name$	 btnPrélever��5#      $��2��6&   $��5��66   $��	Prélever��6C   $��30(�6V   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��60��6�   6�   �� 5$   
   -   5        $	 btnMenu��5$      $
��Menu��6"   $��6��61   $��1��6>   $��30(�6N   $	��120��6\   $��132,40,148,-20q�6h   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��2��6�   6�   �� 5%   
   -	   5        $	 btnQuit��5%      $��Quitter��6"   $��6��64   $��2��6A   $��30(�6Q   $	��120��6_   $��145,40,145,-20q�6k   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��3��6�   6�   5'      5(      