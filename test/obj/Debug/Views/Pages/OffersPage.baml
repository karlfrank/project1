   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElibriumWPF.ViewsElibriumWPF.Views  5      "    ElibriumWPF.Views.OffersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ElibriumWPF.Views     5        N� Title$  
OffersPage��5	       N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ lvOffers��5   W   $��0,30,620,290q�6�   ��6   �� *Offers+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5      ��  �� Width$ 45��6&    �� DisplayMemberBinding 62   �� *Id+$ PropertyChanged=�.��5      �� 
 � Tag$ Id��6/   $��Id��68   5      �� 5      $	 348��6&    63   �� *Title+$ PropertyChanged=�.��5      �� $ Title��6/   $��Title��6;   5      5      5      �� 5   
   -   5         ��Name$ txtTitle��5      $
��Left=�6$   $��35��6?   	 �� TextWrapping$
	 Wrap=�6K   $��Insert the title here��6_   $	��Top=�6|   $	��595��6�   $��
415,33,0,0q�6�   6�   �� 5   
   -   5        $ 
txtContent��5      $
��Left=�6&   $	��130��6A   $
	 Wrap=�6N   $*��$Insert the content of the offer here��6b   $	��Top=�6�   $	��595��6�   $��
415,80,0,0q�6�   �� 5   
   -   5        $ lvCustomers��5      $
��Left=�6�   $	��189��6�   $	��Top=�6�   $	��400��6�   $��	0,294,0,0q�6   ��6(   �� * CustomersHasOffersInSelections+$ PropertyChanged=� 5      �� 5      .P�5      �� $ 80��6&    62   �� *Id+$ PropertyChanged=�.��5       �� $ Id��6/   $��Id��68   5!      �� 5"      $	 100��6&    63   �� *	OfferId+$ PropertyChanged=�.��5#      �� $ OfferId��6/   $��OfferId��6=   5$      �� 5%      $	 100��6&    63   �� *Person.Name+$ PropertyChanged=�.��5&      �� $ Person.Name��6/   $��Person��6A   5'      �� 5(      $	 100��6&    63   �� *Status+$ PropertyChanged=�.��5)      �� $ Status��6/   $��Status��6<   5*      5+      5-      �� 5.   
   -   5        
 ��Name$
 btnAddOffer��5.      $��Save as New��6&   $
��Left=�6<   $	��Top=�6W   $��85��6o   $��415,225,0,0q�6z   $��25��6�   6�   �� 5/   
   -   5        $
 btnEditOffer��5/      $
��Edit��6'   $
��Left=�66   $	��Top=�6Q   $��90��6i   $��510,225,0,0q�6t   $��25��6�    J� RenderTransformOrigin$ 
0.577,2.12&�6�   6�   �� 50   
   -   5        $
 btnDeleteOffer��50      $��Delete��6)   $
��Left=�6:   $	��Top=�6U   $��88��6m   $��606,225,0,0q�6x   $��25��6�   6�   �� 51   
   -   5        $
 btnAddCustomer��51      $��Add Customer��6)   $
��Left=�6@   $	��Top=�6[   $	��200��6s   $��415,428,0,0q�6   $��25��6�   6�   �� 52   
   -	   5        $
 btnRemoveCustomer��52      $��Remove��6,   $
��Left=�6=   $	��Top=�6X   $	��200��6p   $��415,458,0,0q�6|   $��25��6�   6�   (  "System.Windows.Controls.DatePicker  53   
   -
   5        $��dateFrom��53      $
��Left=�6%   $	��Top=�6@   $��	9,229,0,0q�6X   $��22��6k   $	��130��6w     54   
   -   5        $��dateTo��54      $
��Left=�6#   $	��Top=�6>   $��139,229,0,0q�6V   $��22��6k   $	��130��6w   �� 55   
   -   5         ��Name$ label��55      $��Offer is active from��6   $
��Left=�6>   $	��Top=�6Y   $��	9,208,0,0q�6q   $	��130��6�   �� 56   
   -   5        $ label1��56      $��Offer is active to��6    $
��Left=�6=   $	��Top=�6X   $��144,208,0,0q�6p   $	��125��6�   �� 57   
   -   5         ��Name$ cBoxCustomers��57      $
��Left=�6*   $	��Top=�6E   $	��200��6]   $��415,352,0,0q�6i   �� 58   
   -   5        $ labelSelectedCustomers��58      $��Customers in selection��60   $
��Left=�6Q   $��	0,271,0,0q�6l   $	��Top=�6   $ 0.556,0.043&�6�   $	��155��6�   �� 59   
   -   5        $ labelOffers��59      $��Offers��6%   $
��Left=�66   $	��Top=�6Q   $��0,10,0,0q�6i   �� 5:   
   -   5        $ label3��5:      $+��%Select a customer to add to the offer��6    $
��Left=�6P   $	��Top=�6k   $��415,322,0,0q�6�   $	��205��6�   �� 5;   
   -   5        $ 	searchBox��5;      $
��Left=�6%   $��22��6@   $
	 Wrap=�6L   $��TextBox��6`   $	��Top=�6o   $	��200��6�   $��415,294,0,0q�6�   �� 5<   
   -   5        $
 btnEditStatus��5<      $��Change Status��6(   $
��Left=�6@   $	��Top=�6[   $	��176��6s   $��620,398,0,0q�6   $��24��6�   6�   �� 5=   
   -   5        $ cBoxStatuses��5=      $
��Left=�6)   $	��Top=�6D   $	��176��6\   $��620,352,0,0q�6h   $ -0.095,5.262&�6}   �� 5>   
   -   5        $ label4��5>      $#��Select a status for the offer��6    $
��Left=�6H   $	��Top=�6c   $��620,322,0,0q�6{   $	��211��6�   �� 5?   
   -   5        $
 btnSendOffer��5?      $��Send Offer for Customer��6'   $
��Left=�6I   $	��Top=�6d   $	��200��6|   $��415,398,0,0q�6�   $��25��6�   6�   5@      5A      