   M S B A M L   `   `   `  ����  
MailSender     MailSender.Views.EmailInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  5      "ignorehttp://www.ignore.com  5      $
��Auto��5
   ?   $
��Auto��6M     � DataContext  6   �� *Main+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .  (System.Windows.Interactivity.Interaction   Triggers 5   
   /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6&   �� *ReadAllMailsCommand+5      .+�5   
   �� $
��Wrap=�6    �� TextAlignment$ Center=�5      $-��'Получатели сообщений��6$   $
��Bold"�6@   �� 5   
   -   5         ��Name$ btnloadallemails��5      $'��!Отобразить данные��6+   $��3��5      $
��Bold"�5      $	��140��5      ��5      �� *ReadAllMailsCommand+&   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dgEmails��5      $��2��6%   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 5      $��	0,10,0,28q�6    J� RenderTransformOrigin$ 0.5,0.5&�60      
IsReadOnly . ��5   2   �� *Emails+ �� SelectedItem 6Q   �� *CurrentEmail+5!      5"      5#      