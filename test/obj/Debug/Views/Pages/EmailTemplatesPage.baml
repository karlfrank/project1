   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Elibrium.ViewsElibrium.Views  5      '    !Elibrium.Views.EmailTemplatesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Elibrium.Views     5        N� Title$  EmailTemplatesPage��5	       N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ lvEmails��5   W   $��	0,0,620,0q�6�   ��6   �� *Emails+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5      ��  �� Width$ 45��6&    �� DisplayMemberBinding 62   �� *Id+$ PropertyChanged=�.��5      �� 
 � Tag$ Id��6/   $��Id��68   5      �� 5      $	 350��6%    61   �� *Header+$ PropertyChanged=�.��5      �� $ Header��6/   $��Header��6<   5      5      5      �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��35��6>   	 �� TextWrapping$
	 Wrap=�6J   $��TextBox��6^   $	��Top=�6m   $	��596��6�   $��	414,0,0,0q�6�   �� 5   
   -   5        $ textBox1��5      $
��Left=�6$   $	��140��6?   $
	 Wrap=�6L   $��TextBox��6`   $	��Top=�6o   $	��596��6�   $��
414,48,0,0q�6�   �� 5   
   -   5        $ listView��5      $
��Left=�6%   $	��240��6@   $	��Top=�6M   $	��391��6e   $��414,250,0,0q�6q    5      �� 5      .P�5      �� 5      5!      �� 5"   
   -   5        
 ��Name$
 button��5"      $��Save as New��6!   $
��Left=�67   $	��Top=�6R   $	��193��6j   $��817,193,0,0q�6v   $��25��6�   �� 5#   
   -   5        $
 button_Copy��5#      $
��Edit��6&   $
��Left=�65   $	��Top=�6P   $	��193��6h   $��817,223,0,0q�6t   $��25��6�   �� 5$   
   -   5        $
 button_Copy1��5$      $��Add Customer��6'   $
��Left=�6>   $	��Top=�6Y   $	��200��6q   $��810,465,0,0q�6}   $��25��6�   �� 5%   
   -   5        $
 button_Copy2��5%      $��Delete Customer��6'   $
��Left=�6A   $	��Top=�6\   $	��200��6t   $��810,435,0,0q�6�   $��25��6�   (  "System.Windows.Controls.DatePicker  5&   
   $
��Left=�6   $	��Top=�60   $��414,216,0,0q�6H   $��22��6]   $	��121��6i     5'   
   $
��Left=�6   $	��Top=�60   $��535,216,0,0q�6H   $��22��6]   $	��130��6i   �� 5(   
   -	   5         ��Name$ comboBox��5(      $
��Left=�6%   $	��Top=�6@   $	��130��6X   $��670,216,0,0q�6d   �� 5)   
   -
   5         ��Name$ label��5)      $��Active from��6   $
��Left=�65   $	��Top=�6P   $��414,197,0,0q�6h   $	��113��6}   �� 5*   
   -   5        $ label1��5*      $��	Active to��6    $
��Left=�64   $	��Top=�6O   $��535,197,0,0q�6g   $	��130��6|   �� 5+   
   -   5        $ label2��5+      $��Type of Email-Template��6    $
��Left=�6A   $	��Top=�6\   $��670,197,0,0q�6t   �� 5,   
   -   5        $ 	comboBox1��5,      $
��Left=�6&   $��817,253,0,0q�6A   $	��Top=�6V   $	��193��6n   5-      5.      