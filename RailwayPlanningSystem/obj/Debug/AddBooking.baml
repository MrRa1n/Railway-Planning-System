   M S B A M L   `   `   `  ����P  LRailwayPlanningSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RailwayPlanningSystemRailwayPlanningSystem  5   	   &     RailwayPlanningSystem.AddBooking   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RailwayPlanningSystem     5   	   -   5          � Title$  
AddBooking��5   	   $��549.26��6   $��318.216��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ lblName��5
      $��Name:��6!   $
��Left=�61   $��	74,64,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ 
lblTrainID��5      $��Train:��6$   $
��Left=�65   $��	80,95,0,0q�6P   $	��Top=�6c   �� 5   
   $��Add Booking��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   $��24(�6l   �� 5   
   -   5        $ lblDeparture��5      $��Departure Station:��6&   $
��Left=�6C   $��
13,175,0,0q�6^   $	��Top=�6r   �� 5   
   -   5        $ 
lblArrival��5      $��Arrival Station:��6$   $
��Left=�6?   $��
31,205,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5        $ lblFirstClass��5      $��First Class:��6'   $
��Left=�6>   $��
54,242,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ lblCabin��5      $��Cabin:��6"   $
��Left=�63   $��
75,294,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ lblCoach��5      $��Coach:��6"   $
��Left=�63   $��
73,350,0,0q�6N   $	��Top=�6b   �� 5   
   -	   5        $ lblSeat��5      $��Seat:��6!   $
��Left=�61   $��
82,381,0,0q�6L   $	��Top=�6`   �� 5   
   -
   5         ��Name$ txtName��5      $
��Left=�6#   $��23��6>   $��
124,66,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��152��6�   �� 5   
   -   5         ��Name$ 
listTrains��5      $
��Left=�6&   $��69��6A   $��124,100,0,0q�6M   $	��Top=�6b   $	��152��6z   6�   �� 5   
   -   5         ��Name$ comboDeparture��5      $
��Left=�6+   $��124,178,0,0q�6F   $	��Top=�6[   $	��152��6s   5      �� 5   
   -   5        $ comboArrival��5      $
��Left=�6)   $��124,208,0,0q�6D   $	��Top=�6Y   $	��152��6q   5      �� 5   
   $
��Left=�6   $��38��60   $��124,248,0,0q�6<   $	��Top=�6Q   $	��120��6i   .+�5      	� -   5         	�Name$ rdoFirstClassYes��5      $	��Yes��64   $��0,0,0,5q�6B   	� 5      -   5        $ rdoFirstClassNo��5      $��No��63   $��0,0,0,5q�6@    d� 	IsChecked$
 TrueY�6Q   5      �� 5   
   $
��Left=�6   $��42��60   $��124,300,0,0q�6<   $	��Top=�6Q   $	��120��6i   .+�5       	� -   5        $ rdoSleeperYes��5       $	��Yes��61   $��0,0,0,5q�6?   	� 5!      -   5        $ rdoSleeperNo��5!      $��No��60   $��0,0,0,5q�6=   $
 TrueY�6N   5"      �� 5#   
   -   5        $ 
comboCoach��5#      $
��Left=�6'   $��124,353,0,0q�6B   $	��Top=�6W   $	��152��6o   5%      �� 5&   
   -   5        $ 	comboSeat��5&      $
��Left=�6&   $��124,384,0,0q�6A   $	��Top=�6V   $	��152��6n   �� 5'   
   -   5         ��Name$ btnAddBooking��5'      $��Add Booking��6(   $
��Left=�6>   $��
13,476,0,0q�6Y   $	��Top=�6m   $	��281��6�   $��30��6�   {�.  6�   �� 5(   
   -   5        $ btnCalculateFare��5(      $��Calculate Fare��6+   $
��Left=�6D   $��
13,443,0,0q�6_   $	��Top=�6s   $	��281��6�   $��28��6�   6�   5*      5+      