   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElibriumWPF.ViewsElibriumWPF.Views  5      #    ElibriumWPF.Views.ClientsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ElibriumWPF.Views     5        N� Title$  ClientsPage��5      $	��481��6   $	��999��6%    N� 
Background
 ��ح� � 	Resources 5
       
  Brush1 �� EndPoint � MappingMode �� 
StartPoint �� Opacity � Color � Offset��%�   &	        �� 5   
   $ 22.5,20&�6-   $ Absolute=�6@   $ 22.5,0&�6W   $	 0.9Q�6k   .��5      � $ Black��6   � 5      $ 	#FF51FF00��6   $ 0.703Q�6-   � 5      $ 	#FF00CD09��6   $
 0.36Q�6-   5      5      .��5      � $��	1,-44,0,0q�6   	 � ColumnDefinitions	 5   
   �� 5      $	��998 �6   .+�5   
   �� -   5        
 ��Name$	
 btn��5      $	��Add��6   $
��Left=�6,   $	��Top=�6G   $��90��6_   $��310,358,0,0q�6j   $��19��6�    J� RenderTransformOrigin$ -0.93,0.737&�6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��22��6>   $��	0,373,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��135��6�   �� 5   
   -   5         ��Name$ 	labelName��5      $
��Name��6#   $
��Left=�62   $��	0,350,0,0q�6M   $	��Top=�6`   $��23��6x   $��62��6�   �� 5   
   -   5        $ txtBusinessNo��5      $
��Left=�6)   $��22��6D   $��140,373,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��155��6�   �� 5   
   -   5        $ labelBusinessNo��5      $��Business No��6)   $
��Left=�6?   $��140,350,0,0q�6Z   $	��Top=�6o   $��23��6�   $��75��6�   �� 5   
   -   5        $��	lvClients��5   W   $��0,92,598,180q�6�   ��6   �� *	Clients+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5      ��  �� Width$ 45��6&    �� DisplayMemberBinding 62   �� *Id+$ PropertyChanged=���5       �� 5!      
 � Tag$ Id��63   4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm . $��SemiBold"�6j   #���   6�   .��6�   Id5"      5$      �� 5%      $	 200��6%    61   �� *Name+$ PropertyChanged=���5&      �� 5'      $
 Name��63   #���   6>   $��SemiBold"�6d   .��6z   Name6�   5)      �� 5*      $	 148��6%    61   �� *
BusinessNo+$ PropertyChanged=���5+      �� 5,      $ 
BusinessNo��63   #���   6D   $��SemiBold"�6j   .��6�   Business No6�   5.      5/      51      �� 52   
   -   5        $
 refresh��52      $��Refresh��6"   $
��Left=�6J   $��
300,65,0,0q�6e   $	��Top=�6y   $��99��6�   $��22��6�   �� 53   
   -   5        $
 delete��53      $��Delete��6!   $
��Left=�62   $��310,386,0,0q�6M   $	��Top=�6b   $��90��6z   $��19��6�   $ -0.959,2&�6�   �� 54   
   -	   5        $ label1��54      $��Search��6    $
��Left=�61   $	��Top=�6L   $��0,46,0,0q�6d   $ 1.512,0.541&�6v   $��23��6�   $��47��6�   $��SemiBold"�6�   �� 55   
   -
   5        $
 btn_Copy��55      $��Save as Selected��6#   $
��Left=�6>   $	��Top=�6Y   $��89��6q   $��310,412,0,0q�6|   $��19��6�   �� 56   
   -   5        $ 	searchBox��56      $��22      ��6%   $
 Wrap=�57      $�� ��6   $	��Top=�6$   $��0,65,0,0q�6<   $ -2.292,-9.304&�6N   $
��Left=�6�   $	��215��6�   �� 58   
   -   5         ��Name$ lvOffers��58      $
��Left=�6%   $	��272��6@   $	��Top=�6M   $	��443��6e   $��
530,73,0,0q�6q    59      �� 5:      .P�5;      �� $	 100��6%    61   �� *Person.Name+$ PropertyChanged=���5<      �� 5=      $ Person.Name��63   .��6E   Person6M   5?      �� 5@      $	 100��6%    61   �� *Offer.Title+$ PropertyChanged=���5A      �� 5B      $ Offer.Title��63   .��6E   Offer6L   5D      �� 5E      $	 140��6%    61   �� *Offer.DateTo+$ PropertyChanged=���5F      �� 5G      $ Offer.DateTo��63   .��6F   Active until6T   5I      �� 5J      $	 100��6%    61   �� *Status+$ PropertyChanged=���5K      �� 5L      $ Status��63   .��6@   Status6H   5N      5O      5Q      �� 5R   
   -   5        $ activeOffers��5R      $��Active Offers��6&   $
��Left=�6>   $	��Top=�6Y   $��
530,46,0,0q�6q   $	��140��6�   $��SemiBold"�6�   5S      5T      