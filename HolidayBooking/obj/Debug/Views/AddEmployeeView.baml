   M S B A M L   `   `   `  ����I  EHolidayBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:HolidayBooking.ViewModels.DesignTime$HolidayBooking.ViewModels.DesignTime  5   	   *    $HolidayBooking.Views.AddEmployeeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   MholidayBooking2clr-namespace:HolidayBooking.ViewModels.DesignTime     5   	     � Title$  HolidayBooking��5   	   $	��360��6    $	��525��6-    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��2��6    5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$
 Home��5   2   $��0��6   $��0��6%   $
��Home��6@   ��6O   �� *HomeCommand+�� 5      -   5        $ bookHolidays��5   2   $��1��6   $��0��6%   $��BookHolidays��6H   ��6_   �� *BookHolidaysCommand+�� 5       -   5        $ addEmployee��5    3   $��2��6   $��0��6&   $��AddEmployee��6H   
����+����6^   �� *AddEmployeeCommand+6�   �� 5!      -   5        $ Reports��5!   2   $��3��6   $��0��6%   $��Reports��6C   ��6U   �� *ReportsCommand+5"      �� 5#   
   $��Employee Name��6   $��1��6(   $��0��65   $��10,10,145,10q�6E   �� 5$   
   $��1��6   $��0��6   $��115,10,20,10q�6/   $��10,4,2,4q�6�   ��6E   �� *EmployeeRecord.EmployeeName+ �� ValidatesOnDataErrors . 6�   �� 5%   
   $��Joining Date��6   $��1��6'   $��1��64   $��10,10,150,10q�6D   (  "System.Windows.Controls.DatePicker  5&   
   $��1��6   $��1��6"   $��100,10,30,10q�62      SelectedDate 6H   �� *EmployeeRecord.JoiningDate+�� 5'   
   $��Holidays Entitled��6   $��2��6,   $��0��69   $��10,10,140,10q�6I   �� 5(   
   $��2��6   $��0��6   $��140,10,20,10q�6/   $��	35,4,20,4q�6�   ��6E   �� *!EmployeeRecord.HolidaysEntitled+ . 6�   �� 5)   
   $��2��6   $��1��6   $��80,10,30,10q�6.   $	��Add��6C   ��6Q   �� *AddEmployeeRecordCommand+� 5+   
   $��3��6   $��2��6   $��0��6-   $��2��6=   
�������$��10q�6h   .+�5-      &   System.Windows.Controls.DataGrid  -   5        $��EmployeesListGrid��5-      
������    AutoGenerateColumns .     
IsReadOnly . $
��Auto��52      $��Hidden=�53      	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 54      $��10q�55      
   SelectionMode$
 Single=�56         AlternatingRowBackground
 �����$��Stretch=�58      ��5.      �� *EmployeesList+   Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Name��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *EmployeeName+6N     5;      $ Date Joined��6]    6-   �� *JoiningDate+ �� StringFormat$ d��6]     5<      $ Holidays Entitled��6S    6-   �� *HolidaysEntitled+6S   4  .System.Windows.Controls.DataGridTemplateColumn  5=      $ Dormant��6-      CellTemplate 5>      �� 5?      .R�5@   "   �� $��50,0,0,0q�6n    d� 	IsChecked 6+   �� *	Dormant+ �� UpdateSourceTrigger$ PropertyChanged=�6n   5A      5C      5E      5G      5I      5J      