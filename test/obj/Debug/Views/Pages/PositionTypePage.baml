   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ElibriumWPF.Views.PagesElibriumWPF.Views.Pages  5      .    (ElibriumWPF.Views.Pages.PositionTypePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ElibriumWPF.Views.Pages     5        N� Title$  PositionTypePage��5	       N� 
Background
 ��ح�.��5      �  � ColumnDefinitions 5   
   �� 5      $��400px �6   �� 5      $	��45* �6   �� 5      $
��167* �6   .+�5   
   �� -   5         ��Name$ lvPositionTypes��5   ^   ��6   �� *PositionTypes+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5      ��  �� Width$ 45��6&    �� DisplayMemberBinding 62   �� *Id+$ PropertyChanged=���5      �� 5      
 � Tag$ Id��63   $��Id��6<   5      �� 5      $	 348��6%    61   �� *Name+$ PropertyChanged=���5      �� 5      $
 Name��63   $
��Name��6>   5      5      5!      �� 5"   
   -   5        	 ��Name$	 btnAddPositionType��5"      $	��Add��6-   $	��Top=�6;   $��1��6S   $��
15,65,32,0q�6c   $��20��6�   �� 5#   
   -   5        
 ��Name$
 txtPositionTypeName��5#      $��1��6/   $
��Left=�6?   $��22��6Z   $��	15,33,0,0q�6f    �� TextWrapping$
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��196��6�   $��2��6�   �� 5$   
   -   5         ��Name$ labelPositionTypeName��5$      $��Contact Type Name��6/   $��1��6K   $
��Left=�6[   $��	15,10,0,0q�6v   $	��Top=�6�   �� 5%   
   -   5        $	 btnDeletePositionType��5%      $��Delete��60   $��1��6A   $
��Left=�6Q   $��
114,65,0,0q�6l   $	��Top=�6�   $��97��6�   $��2��6�   �� 5&   
   -   5        $	 btnSavePositionType��5&      $��Save as Selected��6.   $
��Left=�6I   $	��Top=�6d   $	��196��6|   $��1��6�   $��	15,90,0,0q�6�   $��30��6�   $��2��6�   5'      5(      