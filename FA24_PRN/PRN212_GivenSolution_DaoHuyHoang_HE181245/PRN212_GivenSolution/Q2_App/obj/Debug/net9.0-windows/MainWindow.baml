   M S B A M L   `   `   `  ����A  =Q2_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Q2_AppQ2_App  5   	       Q2_App.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Q2_App     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgData��5
         AutoGenerateColumns$ False��6#   $��25,54,278,89q�6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ BookID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *BookId+6P     5      $ Title��6%   $	 100 6N    64   �� *Title+6N     5      $ 	Publisher��6%   $	 150 6V    68   �� *	Publisher+6V     5      $ Publication Year��6%   $	 100 6c    6?   �� *PublicationYear+6c   5      �� 5   
   $��Book ID��6   $��
566,40,0,0q�6#   $
��Left=�67   $	��Top=�6R   �� 5   
   -   5         ��Name$ 	txtBookID��5      $��
566,60,0,0q�6%   $	��120��69   $
��Left=�6E   $	��Top=�6`   �� 5   
   $��Title��6   $��566,100,0,0q�6!   $
��Left=�66   $	��Top=�6Q   �� 5   
   -   5        $ txtTitle��5      $��566,120,0,0q�6$   $	��120��69   $
��Left=�6E   $	��Top=�6`   �� 5   
   $��	Publisher��6   $��566,160,0,0q�6%   $
��Left=�6:   $	��Top=�6U   �� 5   
   -   5        $ txtPublisher��5      $��566,180,0,0q�6(   $	��120��6=   $
��Left=�6I   $	��Top=�6d   �� 5    
   $��Publication Year��6   $��566,220,0,0q�6,   $
��Left=�6A   $	��Top=�6\   �� 5!   
   -   5        $ txtPublicationYear��5!      $��566,240,0,0q�6.   $	��120��6C   $
��Left=�6O   $	��Top=�6j   �� 5$   
   -   5         ��Name$ btnSave��5$      $��Save Changes��6"   $��603,290,0,0q�69   $
��Left=�6N   $	��Top=�6i   6�   5&      5'      