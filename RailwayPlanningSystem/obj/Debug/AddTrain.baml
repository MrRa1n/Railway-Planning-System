   M S B A M L   `   `   `  ����P  LRailwayPlanningSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RailwayPlanningSystemRailwayPlanningSystem  5   	   $    RailwayPlanningSystem.AddTrain   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RailwayPlanningSystem     5   	   -   5          �Name$  	AddTrain1��5   	    � Title$ 	Add Train��5   	   $��548.916��6   $��317.713��6,   .��5	      � $��0,0,3.8,0.2q�6   .+�5
   
   �� $��
Departure:��6   $
��Left=�6%   $��	45,65,0,0q�6@   $	��Top=�6S   �� 5   
   $��Destination:��6   $
��Left=�6'   $��	38,96,0,0q�6B   $	��Top=�6U   �� 5   
   $��Type:��6   $
��Left=�6    $��
74,122,0,0q�6;   $	��Top=�6O   �� 5   
   $��Intermediate:��6   $
��Left=�6(   $��
31,155,0,0q�6C   $	��Top=�6W   �� 5   
   $��Departure Time:��6   $
��Left=�6*   $��
17,257,0,0q�6E   $	��Top=�6Y   �� 5   
   $��Departure Day:��6   $
��Left=�6)   $��
17,300,0,0q�6D   $	��Top=�6X   �� 5   
   $��Sleeper Cabin:��6   $
��Left=�6)   $��
26,347,0,0q�6D   $	��Top=�6X   �� 5   
   $��First Class:��6   $
��Left=�6'   $��
46,395,0,0q�6B   $	��Top=�6V   �� 5   
   -   5         ��Name$ comboDeparture��5      $
��Left=�6+   $��
128,69,0,0q�6F   $	��Top=�6Z   $	��150��6r   .@�5      �� $��Edinburgh (Waverley)��6   �� 5      $��London (Kings Cross)��6   5      �� 5   
   -   5        $ comboDestination��5      $
��Left=�6-   $��
128,99,0,0q�6H   $	��Top=�6\   $	��150��6t   .@�5      �� $��Edinburgh (Waverley)��6   �� 5      $��London (Kings Cross)��6   5      �� 5   
   -   5        $ 	comboType��5      $
��Left=�6&   $��128,127,0,0q�6A   $	��Top=�6V   $	��150��6n   .@�5      �� $��Express��6   �� 5      $��Stopping��6   �� 5      $��Sleeper��6   5      �� 5   
   -   5         ��Name$ stackIntermediates��5      $
��Left=�61   $��88��6L   $��128,164,0,0q�6X   $	��Top=�6m   $	��150��6�   .+�5       �� -   5         ��Name$ chkNewcastle��5       $��	Newcastle��6-   $��	0,0,5.4,5q�6A   �� 5!      -   5        $ chkDarlington��5!      $��
Darlington��6.   $��0,0,5,5q�6C   �� 5"      -   5        $ chkYork��5"      $
��York��6(   $��0,0,5,5q�67   �� 5#      -	   5        $ chkPeterborough��5#      $��Peterborough��60   $��	0,0,5.4,5q�6G   5$      (  "System.Windows.Controls.DatePicker  5%   
   -
   5          Name$ dateDepartureDay��5%      $
��Left=�6/   $��128,302,0,0q�6J   $	��Top=�6_   $	��150��6w   �� 5&   
   -   5        $ comboDepartureTime��5&      $
��Left=�6/   $��128,257,0,0q�6J   $	��Top=�6_   $	��150��6w   �� 5'   
   $
��Left=�6   $��42��60   $��128,354,0,0q�6<   $	��Top=�6Q   $	��150��6i   .+�5(      	� -   5         	�Name$ rdoSleeperYes��5(      $	��Yes��61   $��0,0,0,5q�6?   	� 5)      -   5        $ rdoSleeperNo��5)      $��No��60   $��0,0,0,5q�6=    d� 	IsChecked$
 TrueY�6N   5*      �� 5+   
   $
��Left=�6   $��42��60   $��128,402,0,0q�6<   $	��Top=�6Q   $	��150��6i   .+�5,      	� -   5        $ rdoFirstClassYes��5,      $	��Yes��64   $��0,0,0,5q�6B   	� 5-      -   5        $ rdoFirstClassNo��5-      $��No��63   $��0,0,0,5q�6@   $
 TrueY�6Q   5.      �� 5/   
   -   5         ��Name$ btnAddTrain��5/      $��	Add Train��6&   $
��Left=�6:   $��30��6U   $��
17,463,0,0q�6a   $	��Top=�6u   $	��261��6�   6�   �� 50   
   $��	Add Train��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $��24(�6j   52      53      