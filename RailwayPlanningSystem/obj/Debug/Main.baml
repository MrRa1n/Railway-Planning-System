   M S B A M L   `   `   `  ����P  LRailwayPlanningSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RailwayPlanningSystemRailwayPlanningSystem  5   	        RailwayPlanningSystem.Main   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RailwayPlanningSystem     5   	   -   5          �Name$  frmMain��5   	    � Title$
 Main��5   	   $��681.951��6   $	��950��6'   $	��950��63   $	��700��6B   $	��950��6R   $	��660��6a   $
��Left=�6q   $	��Top=�6�   .��5	      � $��0,0,10,0q�6   .+�5
   
   �� -   5         ��Name$ lblRailwayPlanningSystem��5
      $��Railway Planning System��62   $
��Left=�6T   $��	10,10,0,0q�6o   $	��Top=�6�   $��24(�6�   �� 5   
   -   5         ��Name$ btnAddTrain��5      $��	Add Train��6&   $
��Left=�6:   $��32��6U   $��10,599,0,10q�6a   $	��Top=�6v   $	��112��6�   6�   �� 5   
   -   5        $ btnAddBooking��5      $��Add Booking��6(   $
��Left=�6>   $��127,599,0,10q�6Y   $	��Top=�6o   $	��112��6�   $��32��6�   6�   �� 5   
   -   5        $ btnSaveTrains��5      $
��Save��6(   $
��Left=�67   $��679,599,0,10q�6R   $	��Top=�6h   $	��120��6�   $��32��6�   6�   �� 5   
   -   5        $ btnLoadTrains��5      $
��Load��6(   $
��Left=�67   $��804,599,0,10q�6R   $	��Top=�6h   $	��116��6�   $��32��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataAllTrains��5      $��
10,124,0,0q�6B   $	��Top=�6V      
IsReadOnly . $	��900��6�   $	��210��6�   $	��210��6�   $
��Left=�6�   $	��910��6�      SelectionMode$ Single=�6  ��6*   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   Z� 	   ClipboardContentBinding	 68   Z� 
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value$ 	10,5,10,5q�60   �� 5       � �� 5      �� 5       �� 
TargetType"  6.   .R�5   "   ��  �� Padding# z��6)   #��z��6M   #��z��6y   #��z��6�    J� SnapsToDevicePixels . ._�5   &   �� # z 67   5   #   5      5      5      5!        5"   
   -   5        $ dataPassengerList��5"      $��
10,377,0,0q�6F   $	��Top=�6Z    . $	��900��6�   $	��210��6�   $	��208��6�   $	��210��6�   $
��Left=�6�   $	��910��6�   $ Single=�6�   ��6.   ��  5#        5$       6%   Z� 	 68   Z� 
 5&      �� 5'      "  6   .�5(      ��  � ��$ 	10,5,10,5q�60   �� 5)       � �� 5*      �� 5+      "  6.   .R�5,   "   �� # z��6)   #��z��6M   #��z��6y   #��z��6�    . ._�5-   &   �� # z 67   5.   #   5/      51      52      54      �� 55   
   -	   5        $ lblAllTrains��55      $��
Train List��6&   $
��Left=�6;   $��	10,87,0,0q�6V   $	��Top=�6i   $��79��6�   $��16(�6�   �� 56   
   -
   5        $ lblPassengerList��56      $��Passenger List��6*   $
��Left=�6C   $��
10,340,0,0q�6^   $	��Top=�6r   $��16(�6�   �� 57   
   $
��Left=�6   $	��109��60   $��
563,10,0,0q�6=   $	��Top=�6Q   $	��357��6i   .@�58      �� $��Find Trains by Day��6   .��59      � 
�������.+�5:      (  "System.Windows.Controls.DatePicker  -   5          Name$ dateViewTrains��5:   !   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $	��226��6      DisplayDate$ 
2018-11-30��6�   �� 5;      -   5        $ btnViewTrains1��5;      $��View Trains��65   $
��Left=�6K   $��
241,10,0,0q�6f   $	��Top=�6z   $	��100��6�   $��24��6�   6�   5<      5=      �� 5>      $��Between Two Stations��6   .��5?      � 
�������.+�5@      �� -   5         ��Name$ comboDeparture��5@      $
��Left=�67   $��	88,10,0,0q�6R   $	��Top=�6e   $	��148��6}   �� 5A      -   5        $ comboArrival��5A      $
��Left=�65   $��	88,39,0,0q�6P   $	��Top=�6c   $	��148��6{   �� 5B      -   5        $ lblDeparture��5B      $��
Departure:��62   $
��Left=�6G   $��6,7,0,0q�6b   $	��Top=�6s   �� 5C      -   5        $ 
lblArrival��5C      $��Arrival:��60   $
��Left=�6C   $��	25,36,0,0q�6^   $	��Top=�6q   �� 5D      -   5        $ btnFindTrains��5D      $��Search��64   $
��Left=�6E   $��
241,10,0,0q�6`   $	��Top=�6t   $	��100��6�   $��23��6�   6�   5E      5F      5G      5I      5J      