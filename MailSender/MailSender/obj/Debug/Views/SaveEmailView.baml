   M S B A M L   `   `   `  ����  
MailSender$    MailSender.Views.SaveEmailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	     � DataContext  5   	   �� *Main+   Locator �� Source# [  .��5	      � $��0 50 0 0q�6     6   �� *CurrentEmail+ � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��20 �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Wrap=�6   $	��Id:��6(   �� 5   
   $��1��6   $
��Wrap=�6!   $��Value:��65   �� 5   
   $��2��6   $
��Wrap=�6!   $��Name:��65   �� 5   
   -   5        $��1��5       �� TextWrapping$
 Wrap=�6"    �� 
IsReadOnly . {�.  ��6Z   �� *Id+ �� NotifyOnValidationError . 6�   �� 5   
   -   5        $��1��5      $��1��6"   $
 Wrap=�6/   ��6C   �� *Value+ .  �� ValidatesOnDataErrors . 6�   �� 5   
   $��1��6   $��2��6"   $
 Wrap=�6/   ��6C   �� *Name+�� 5   
   $��Сохранить��6   $
��Bold"�5      $��5��6   $��2��5      $��22��5    *   $	��140��5!      ��5      �� *DataContext.SaveMailCommand+ �� RelativeSource �� 	 �� AncestorType$	 UserControlL���5       �� 5!      5"      5#      