   M S B A M L   `   `   `  ����  
ChatClient    ChatClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Chat Window��5   	   $	��400��6   $	��550��6*   .��5      �  � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��150 �6   .+�5   
   � $��0��6   .+�5      �� -   5        $��chatTextBox��5      $
��Left=�6)   $	��Top=�6D   $	��419��6\   $	��177��6h   $��10,0,0,0q�6u   �� 5      -   5         ��Name$ userNameTextBox��5      $
��Left=�6/   $��Bottom=�6J   $	��100��6e   $��30��6q    J� RenderTransformOrigin$ 0.64,-2.199&�6}   $��	10,0,0,10q�6�   �� 5      $��Имя��6   $
��Left=�6"   $��23��6=   $��
10,182,0,0q�6I   $	��Top=�6]   $��64��6u   5      � 5   
   $��1��6   .+�5      �� -   5        $��messageTextBox��5      $
��Left=�6,   $	��302��6G   $��56��6S   $	��Top=�6_   $��	10,38,0,0q�6w   �� 5      -   5        $��
sendButton��5   )   $��Отправить��6   $	��Top=�6;   $��56��6S   $��373,38,57,0q�6x   �� 5      $��Сообщение��6   $
��Left=�6(   $��33��6C   $��10,0,0,0q�6O   $	��Top=�6a   $��96��6y   5      5      5      