   M S B A M L   `   `   `  ����M  Iguichetauto_projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:guichetauto_projetguichetauto_projet  5   	   /    )guichetauto_projet.AdminAfficherTransacOP   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:guichetauto_projet     5   	     � Title$!  Historique des transactions��5      $	��500��69   $	��660��6F    � WindowStartupLocation$ CenterScreen=�6R    � 
ResizeMode$ NoResize=�6w   .��5	      � ���	#FF005DA5 � ColumnDefinitions 5
   
   �� 5      $��20 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      $��60 �6   6*   �� 5      $��10 �6   6*   �� 5      $��60 �6   6*   �� 5      $��10 �6   6*   �� 5      $��60 �6   6*   �� 5      $��30 �6   6*   �� 5      $��60 �6   6*   �� 5      $��10 �6   6*   �� 5      $��80 �6   6*   �� 5       $��80 �6   6*   .+�5"   
   �� -   5         ��Name$ 
lblCodeCli��5"      $��Code client :��6$   $��1��6<   $��1��6L   
�������$��Microsoft JhengHei UI)�6m   $
��Bold"�6�   $��25(�6�   $��50��6�   $��Right=�6�   �� 5#   
   -   5         ��Name$ 
txtCodeCli��5#      $��3��6&   $��1��66   
�������$��Microsoft JhengHei UI)�6V   $
��Bold"�6y   $��25(�6�    �� 	MaxLength$ 10��6�   ���	#FF00CAFF6�   �� 5$   
   -   5         ��Name$ btnAfficherTransac��5$      $��Afficher��6-   
�������$��Microsoft JhengHei UI)�6T   $
��Bold"�6w   $��25(�6�   ���	#FF00CAFF$��1��6�   $��5��6�   6�   �� 5%   
   -   5        	 ��Name$	 
lstTransac��5%      $��1��6&   $��3��66   $��5��6C   $��86,30,86,30q�6W   $��5��6l   
���   �$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��20(�6�   �� 5&   
   -   5        $ btnMenu��5&      $
��Menu��6"   $��9��61   $��1��6>   $��30(�6N   $	��120��6\   $��145,20,145,10q�6h   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��3��6�   $��50��6  �� 5'   
   -   5        $ btnQuit��5'      $��Quitter��6"   $��9��64   $��3��6A   $��30(�6Q   $	��120��6_   $��145,20,145,10q�6k   
����������	#FF00CAFF$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��3��6�   $��50��6  5(      5)      