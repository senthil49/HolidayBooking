   M S B A M L   `   `   `  ����I  EHolidayBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:HolidayBooking.ViewModels.DesignTime$HolidayBooking.ViewModels.DesignTime  5   	   +    %HolidayBooking.Views.BookHolidaysView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   MholidayBooking2clr-namespace:HolidayBooking.ViewModels.DesignTime     5   	     � Title$  HolidayBooking��5   	   $	��360��6    $	��525��6-    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   6*   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $
��Auto �6   6.   .+�5   
   � $��0��6   $��2��6    5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� -   5         ��Name$
 Home��5   2   $��0��6   $��0��6%   $
��Home��6@   ��6O   �� *HomeCommand+�� 5       -   5        $ bookHolidays��5    2   $��1��6   $��0��6%   $��BookHolidays��6H   
����+����6_   �� *BookHolidaysCommand+6�   �� 5!      -   5        $ addEmployee��5!   3   $��2��6   $��0��6&   $��AddEmployee��6H   ��6^   �� *AddEmployeeCommand+�� 5"      -   5        $ Reports��5"   2   $��3��6   $��0��6%   $��Reports��6C   ��6U   �� *ReportsCommand+5#      �� 5%   
   $��	Employees��6   $��1��5&      $��0��5'      $��
30,15,20,5q�5(      $��5q�5)      �� 5*   
   $��1��5+      $��0��5,      $��100,15,20,5q�5-      $��5q�5.      ��5/      �� *EmployeeNames+ �� SelectedItem 50      �� *SelectedEmployee+(  "System.Windows.Controls.DatePicker  52   
   $��1��6   $��1��6"   $��
40,15,20,5q�62   $��5q�6�      SelectedDate 6F   �� *
DateFrom+ �� ValidatesOnDataErrors . 6�     53   
   $��2��6   $��1��6"   $��40,10,20,10q�62   $��5q�6�    6G   �� *DateTo+ . 6�   �� 54   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��0��6;   $��30,10,17,10q�6K   .+�55      �� $��Leaves Remaining��6   �� 56      
�������$��1q�6-   ._�57      �� 	 �� Padding$	 44,05q�6<   ��6   �� *LeaveRemaining+6<   58      59      �� 5:   
   $��3��6   $��0��6   $��2��6/   $��20q�6C   $��10q�6P   ��6]   �� *Reason+�� 5;   
   $��4��6   $��1��6   $��140,0,20,20q�6.   $��20,05,20,05q�6C   $
��Save��6Y   ��6h   �� *SaveCommand+5<      5=      