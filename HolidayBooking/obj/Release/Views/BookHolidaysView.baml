   M S B A M L   `   `   `  ���� I  EHolidayBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:HolidayBooking.ViewModels.DesignTime$HolidayBooking.ViewModels.DesignTime  +    %HolidayBooking.Views.BookHolidaysView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     MholidayBooking2clr-namespace:HolidayBooking.ViewModels.DesignTime       � Title$  HolidayBooking��$	��360��$	��525�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��30 ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+�� $��0��$��2�� �� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$
 Home��$��0��$��0��$
��Home������ *HomeCommand+�� -   $ bookHolidays��$��1��$��0��$��BookHolidays��
����+������ *BookHolidaysCommand+�� -   $ addEmployee��$��2��$��0��$��AddEmployee������ *AddEmployeeCommand+�� -   $ Reports��$��3��$��0��$��Reports������ *ReportsCommand+�� $��	Employees��$��1��$��0��$��
30,15,20,5q�$��5q��� $��1��$��0��$��100,15,20,5q�$��5q����� *EmployeeNames+ �� SelectedItem �� *SelectedEmployee+(  "System.Windows.Controls.DatePicker  $��1��$��1��$��
40,15,20,5q�$��5q�   SelectedDate �� *
DateFrom+ �� ValidatesOnDataErrors .   $��2��$��1��$��40,10,20,10q�$��5q� �� *DateTo+ . ��  �� Orientation$ 
Horizontal=�$��2��$��0��$��30,10,17,10q�.+��� $��Leaves Remaining���� 
�������$��1q�._��� 	 �� Padding$	 44,05q����� *LeaveRemaining+�� $��3��$��0��$��2��$��20q�$��10q����� *Reason+�� $��4��$��1��$��140,0,20,20q�$��20,05,20,05q�$
��Save������ *SaveCommand+