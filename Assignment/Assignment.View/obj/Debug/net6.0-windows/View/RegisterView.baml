   M S B A M L   `   `   `  ����J  FAssignment.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Assignment.View.ViewAssignment.View.View  5   	   E'clr-namespace:Assignment.View.ViewModelAssignment.View.ViewModel  5   	   O,clr-namespace:Assignment.View.CustomControlsAssignment.View.CustomControls  5   	   '    !Assignment.View.View.RegisterView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Assignment.View.View     5   	   =	viewModel'clr-namespace:Assignment.View.ViewModel     5   	   Gcustomcontrols,clr-namespace:Assignment.View.CustomControls     5   	   -   5          � Title$  RegisterView��5
   	   $	��550��6   $	��800��6+    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      1   +Assignment.View.ViewModel.RegisterViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5       �� 
 �� CornerRadius$
 12��6   ��5!   
   �� 5"       �� ImageSource$a [C:\Users\hridya.dham\Documents\C# Projects\Assignment\Assignment.View\Images\back-image.jpg��6   ._�5&   
   �� $
 10��6   $��5q�5'       J� Opacity$
 0.90Q�5(      ��5)      �� 5*       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5+      �  � Color$ #060531��6#    � Offset$ 0Q�63   � 5,      $ #1B1448��6#   $
 0.75Q�63   � 5-      $ #8A16C1��6#   $ 1Q�63   5.      ��50      �� 51      $	 0,1&�6&   $	 1,0&�67   .��52      � $ #462AD8��6#   $ 0Q�63   � 53      $ #DA34AE��6#   $	 .75Q�63   54      ._�58      �  � RowDefinitions 59      �� 5:      $��30 �6$   �� 5;      .+�5?      �  � ColumnDefinitions 5@      �� 5A      �� 5B      $��25 �6+   �� 5C      $��25 �6+   �� 5D      $��5 �6+   .+�5G      �� $��REGISTER��6    
�������$��10(�5I      $��
Montserrat)�5J      $��0��5K      $��Center=�5L      $��10,0,0,0q�5M      �� 5O      -   5         ��Name$ btnMinimize��5O      $��0q�5Q      $��-��5R      
�������$��16(�5T      $��
Montserrat)�5U       � Cursor$
 Hand��5V      $��1��5W      ��5P      �� *MinimizeWindow+��5Z      �� 5[       �� 
TargetType" ��6$   .�5\   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 5]   "   P� 5^   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5_   *   ��  � �� �#278BEF6G   5`   '   5b      ��5e      �� 5f       �� 
TargetType" ��6.   .R�5g   "   �� $��18��6)   $��18��64   $
 9��5h   )   #��z��5i   )   ._�5j   &   �� $��Center=�67   $��Center=�5k   7   5l   #   5m      5p      �� 5r      -   5        $ btnClose��5r      $��0q�5t      $��X��5u      
�������$��12(�5w      $��
Montserrat)�5x      $
 Hand��5y      $��2��5z      ��5s      �� *ShutDownWindow+��5|      �� 5}      " ��6$   .�5~   "   ��  � ��
 �  ��6?    5   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � ��
 �  ��6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $��18��6)   $��18��64   $
 9��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6!   $	��250��5�   !    �� Orientation$ Vertical=�5�   !   $��	0,110,0,0q�5�   !   .+�5�      �� $b��\C:\Users\hridya.dham\Documents\C# Projects\Assignment\Assignment.View\Images\gemini logo.png��6    $	��200��5�      $	��200��6(   $��Center=�5�       $��0,0,15,0q�5�      �� 5�      $��Register��6$   
�������$��25(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��Center=�5�       $��0,10,0,0q�5�       �� 5�      $��Hello There!��6$   
�������$��17(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��Center=�5�       $��0,5,0,0q�5�       �� 5�      $ 
Horizontal=�6%   $��37,0,0,0q�5�   %   .+�5�      �� $��Already have an account?��6(   
�������$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��Center=�5�       $��5,6,0,0q�5�       �� 5�      -   5        $ btnLogin��5�   %   
������ 
������ $��0q�5�   %   $��Login��5�   %   
�������$��12(�5�   %   $��Medium"�5�   %   $��
Montserrat)�5�   %   $
 Hand��5�   %   $��0,0,0,0q�5�   %   ��5�   %   �� *ViewLoginCommand+��5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � ��
 �  ��6G    5�   *   P� 5�   .    �@J�IsMouseOver$
 True��6M   . �5�   2   ��  � ��
 �  ��6O   5�   /   5�   '   ��5�   "   �� 5�   &   " ��66   .R�5�   *   �� $��40��61   $��25��6<   $
 15��5�   )   #��z��5�   )   ._�5�   .   �� $��Center=�6?   $��Center=�5�   7   5�   +   5�   '   5�      5�      �� 5�      
���  ��$��16(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��0,10,0,0q�5�       $��Center=�5�       $
��Wrap=�5�       ��5�   $   �� *ErrorMessage+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�       5�      � 5�      $��1��6   $��0,0,20,0q�6+    5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      .+�5     � $��0��6   $��2��6,   5     � 5     $��1��6   $��0��6,   .+�5
     �� .+�5  "   �� $��
FirstName:��6,   
�������$��12(�5      $��Medium"�5      $��
Montserrat)�5      $��0,20,0,0q�5      �� 5  "   -   5         ��Name$ txtFirstName��5  *   $��13(�5     $��Medium"�5     $��
Montserrat)�5     
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5     $��28��5     $��Center=�5     $��0,5,10,0q�5     $��20,0,0,0q�5     ��5     �� *	FirstName+$ PropertyChanged=�.��5  1   ��5  &   �� 5   *   $` ZC:\Users\hridya.dham\Documents\C# Projects\Assignment\Assignment.View\Images\user-icon.png��65     j� Stretch$
  None=�5!  )   ! j� 
AlignmentX$
! Left=�5"  )   .��5#  :   5%  #   5&     5'     � 5*     $��1��6   $��1��6,   .+�5,     �� $��1��6)   .+�5/  "   �� $��	LastName:��6,   
�������$��12(�51      $��Medium"�52      $��
Montserrat)�53      $��0,20,0,0q�54      �� 55  "   -   5        $ txtLastName��55  *   $��13(�57     $��Medium"�58     $��
Montserrat)�59     
�������
 �����
�������$��0,0,0,2q�5=     $��28��5>     $��Center=�5?     $��0,5,10,0q�5@     $��20,0,0,0q�5A     ��56     �� *
LastName+$ PropertyChanged=�.��5A  1   ��5C  &   �� 5D  *   $` ZC:\Users\hridya.dham\Documents\C# Projects\Assignment\Assignment.View\Images\user-icon.png��65   $
  None=�5E  )   $
! Left=�5F  )   .��5G  :   5H  #   5I     5J     � 5M     $��2��6   $��0��6,   .+�5N     �� .+�5P  "   �� $��Gender:��6,   
�������$��12(�5R      $��Medium"�5S      $��
Montserrat)�5T      $��0,20,0,0q�5U      �� 5V  "   -   5        " ��Name$" 	txtGender��5V  +   $��13(�5Y  '   $��Medium"�5Z  '   $��
Montserrat)�5[  '   
���   �
�������$��0,0,0,2q�5^  '   $��20��5_  '   $��Center=�5`  '   $��	0,13,10,0q�5a  '   $��20,0,0,0q�5b  '   ��5W  '   �� *ComboBoxItems+# �� SelectedItem# 5X  '   �� *Gender+.@�5c  &   �� $��Please Select��63   $ �� 
IsSelected$
$ True��6K   ${�False��6]   �� 5d  &   $
��Male��63   �� 5e  &   $��Female��63   5g  #   5h     5i     � 5l     $��2��6   $��1��6,   .+�5m     �� .+�5n  "   �� $��Date Of Birth:��6,   
�������$��12(�5p      $��Medium"�5q      $��
Montserrat)�5r      $��0,20,0,0q�5s      (  "System.Windows.Controls.DatePicker  5u  "   -   5        $��13(�5x  )   $��Medium"�5y  )   $��
Montserrat)�5z  )   
���   �
������ $��0,0,0,0q�5}  )   $��46��5~  )   $
��Auto��5  )   $��Center=�5�  )   $��0,0,10,0q�5�  )   $��5,0,0,0q�5�  )   %   Text% 5v  )   �� *DOB+$ TwoWay=�5�  )   5�     5�     � 5�     $��3��6   $��2��6,   .+�5�     �� .+�5�  "   �� $��Email:��6,   
�������$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0,20,0,0q�5�      �� 5�  "   -	   5        $ txtEmail��5�  *   $��13(�5�     $��Medium"�5�     $��
Montserrat)�5�     
�������
 �����
�������$��0,0,0,2q�5�     $��28��5�     $��Center=�5�     $��Center=�5�     $��0,5,20,0q�5�     $��20,0,0,0q�5�     ��5�     �� *Email+$ PropertyChanged=�.��5�  1   ��5�  &   �� 5�  *   $` ZC:\Users\hridya.dham\Documents\C# Projects\Assignment\Assignment.View\Images\user-icon.png��65   $
  None=�5�  )   $
! Left=�5�  )   .��5�  :   5�  #   5�     5�     � 5�     $��4��6   $��2 ��6,   .+�5�     �� .+�5�  "   �� $��	Password:��6,   
�������$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0,15,0,0q�5�      8   2Assignment.View.CustomControls.BindablePasswordBox  5�  "   $��28��5�  9   $��0,5,20,0q�5�  9   &   Password& 5�  E   �� *
Password+$ TwoWay=�$ PropertyChanged=�5�  #   5�     5�     � 5�     $��5��6   $��2 ��6,   .+�5�     �� .+�5�  "   �� $��Confirm Password:��6,   
�������$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0,5,0,0q�5�        5�  "   $��28��5�  9   $��0,5,20,0q�5�  9   & 5�  E   �� *ConfirmPassword+$ TwoWay=�$ PropertyChanged=�5�  #   5�     5�     � 5�     $��6��6   $��2��6,   .+�5�     �� -
   5        $ btnRegister��5�  %   $��0q�5�     $��Register��5�     
�������$��12(�5�     $��
Montserrat)�5�     $
 Hand��5�     $��	0,0,30,35q�5�     ��5�     �� *RegisterCommand+��5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��
 �� �6G    5�  *   P� 5�  .    �@J�IsMouseOver$
 True��6M   . �5�  2   ��  � ��
 � � �6O   5�  /   5�  '   ��5�  "   �� 5�  &   " ��66   .R�5�  *   �� $	��180��61   $��30��6=   $
 15��5�  )   #��z��5�  )   ._�5�  .   �� $��Center=�6?   $��Center=�5�  7   5�  +   5�  '   5�     5�     5�     5�     5�     5�     5�     5�     