   M S B A M L   `   `   `  ����>  :CA2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CA2CA2  5   	       CA2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:CA2     5   	   -   5          � Title$  Activity Planner��5   	   $	��450��6"   $	��800��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��155* �6   �� 5      $	��43* �6   .+�5   
   �� -   5         ��Name$ btn_forward��5      $��>>��6&   $
��Left=�69   $��368,119,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $ btn_backward��5      $��<<��6'   $
��Left=�6:   $��368,162,0,0q�6U   $	��Top=�6j   $��75��6�   6�   	� 5   
   -   5         	�Name$ 	rdbtn_All��5      $	��All��6)   $
��Left=�67   $��	26,89,0,0q�6R   $	��Top=�6e    	� 	GroupName$ 
categories��6}   6�   	� 5   
   -   5        $ 
rdbtn_Land��5      $
��Land��6*   $
��Left=�69   $��
26,117,0,0q�6T   $	��Top=�6h   $ 
categories��6�   6�   	� 5   
   -   5        $ rdbtn_water��5      $��Water��6+   $
��Left=�6;   $��
26,143,0,0q�6V   $	��Top=�6j   $ 
categories��6�   6�   	� 5   
   -   5        $ 	rdbtn_Air��5      $	��Air��6)   $
��Left=�67   $��
26,169,0,0q�6R   $	��Top=�6f   $ 
categories��6~   6�   �� 5   
   -   5         ��Name$ 	lstbx_all��5      $
��Left=�6%   $	��251��6@   $��
138,88,0,0q�6M   $	��Top=�6a   $	��192��6y   6�   �� 5   
   -	   5        $ lstbx_selected��5      $
��Left=�6*   $	��255��6E   $��
485,86,0,0q�6R   $	��Top=�6f   $	��181��6~   $��2��6�   �� 5   
   $��All Activities��6   $
��Left=�6)   $��
138,59,0,0q�6D   $	��Top=�6X   �� 5   
   $��Selected Activities��6   $
��Left=�6.   $��
487,58,0,0q�6I   $	��Top=�6]   $	��125��6u   �� 5   
   -
   5         ��Name$ tblk_description��5      $
��Left=�6.   $��140,374,0,0q�6I   $
��Wrap=�6^   $	��Top=�6r   $	��214��6�   �� 5   
   $��Description��6   $
��Left=�6&   $��136,345,0,0q�6A   $	��Top=�6V   �� 5   
   -   5        $ tblk_totalCost��5      $
��Left=�6,   $��438,376,0,0q�6G   $
��Wrap=�6\   $	��Top=�6p    J� RenderTransformOrigin$ 0.5,0.5&�6�   $�� ��6�   �� 5   
   $��Cost -��6   $
��Left=�6!   $��388,370,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5        $ tblk_messages��5      $
��Left=�6+   $��
465,29,0,0q�6F   $
��Wrap=�6Z   $	��Top=�6n   $	��200��6�   $��2��6�   �� 5   
   $��Activity Planner��6   $
��Left=�6+   $��
135,16,0,0q�6F   $	��Top=�6Z   $	��235��6r   $��18(�6~   ���	#FF00A2FF6�   5      5      