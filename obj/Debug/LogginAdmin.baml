   M S B A M L   `   `   `  ����M  Iguichetauto_projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:guichetauto_projetguichetauto_projet  5   	   $    guichetauto_projet.LogginAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:guichetauto_projet     5   	     � Title$  Authentification Admin��5      $	��280��6,   $	��600��69    � WindowStartupLocation$ CenterScreen=�6E    � 
ResizeMode$ NoResize=�6j   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��100 �6   6-    � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      $��30 �6   6*   �� 5      $��10 �6   6*   �� 5      $��30 �6   6*   �� 5      $	��100 �6   6+   .+�5   
   �� -   5         ��Name$ 
lblCodeCli��5      $��1��6$   $��1��64   $��Code :��6A   $��Right=�6R   �� 5   
   -   5        $ 	lblNipCli��5      $��1��6#   $��3��63   $��NIP :��6@   $��Right=�6P   6u   �� 5   
   -   5         ��Name$ txtCodeAdmin��5      $��2��6(   $��1��68    �� 	MaxLength$ 10��6E   $��20(�6T   $	��120��6b   6n   G� 5   
   -   5         G�Name$ txtNipAdmin��5      $��2��6+   $��3��6;   	 G� 	MaxLength$	 4��6H   $��30(�6V   
 G� PasswordChar$
 *��6d   $��Center=�6v   $��60��6�   6�   �� 5   
   $J��DC:\Users\15148\source\repos\guichetauto_projet\Resources\imglock.jpg��6   $��0��6^   $��0��6n   $��5��6{   �� 5   
   -   5         ��Name$ btnOK��5      $��1��6    $��4��60   $��30��6=   $��60��6I   $��OK��6T   $��Center=�6a   6�   �� 5   
   -   5        $ 	btnRetour��5      $��3��6$   $��4��64   $��Retour��6A   $��10,35,30,35q�6R   $��60��6g   6r   �� 5   
   -   5        $ 
btnAnnuler��5      $��2��6%   $��4��65   $��30��6B   $��60��6N   $��Annuler��6Y   $��Center=�6k   6�   5      5       