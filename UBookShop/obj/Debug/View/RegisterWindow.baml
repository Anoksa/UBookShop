   M S B A M L   `   `   `  ????D  @UBookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UBookShop.ViewUBookShop.View  5   	   #    UBookShop.View.RegisterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:UBookShop.View     5   	     ? Title$  RegisterWindow??5   	   $??518.655??6    $??577.809??61   .??5	      ? .+?5
   
   ?? -   5         ??Name$ lNameBox??5
   "   $??Фамилия??6   $
??Left=?64   $??
122,36,0,0q?6O   $	??Top=?6c   ?? 5   
   $
??Left=?6   $??23??6-   $??
185,39,0,0q?69    ?? TextWrapping$
 Wrap=?6M   $	??Top=?6b   $	??237??6z   .??6?   .??5      ??  ?? Path$ LName?6    ?? UpdateSourceTrigger$ PropertyChanged=?6#    ?? ValidatesOnDataErrors .  ?? ValidationRules 5      5  /System.Windows.Controls.ExceptionValidationRule  5      5      5      ?? 5   
   -   5        $ fNameBox??5      $??Имя??6   $
??Left=?60   $??
122,80,0,0q?6K   $	??Top=?6_   ?? 5   
   $
??Left=?6   $??23??6-   $??
185,81,0,0q?69   $
 Wrap=?6M   $	??Top=?6b   $	??237??6z   .??6?   .??5      ?? $ FName?6   $ PropertyChanged=?6#    .  5        5      5      5      ?? 5   
   -   5        $ loginBox??5       $??
Логин??6   $
??Left=?62   $??122,116,0,0q?6M   $	??Top=?6b   ?? 5   
   $
??Left=?6   $??23??6-   $??185,119,0,0q?69   $
 Wrap=?6N   $	??Top=?6c   $	??237??6{   .??6?   .??5      ?? $ Login?6   $ PropertyChanged=?6#    .  5        5       5"      5#      ?? 5'   
   -   5        $ phoneBox??5'   "   $??Телефон??6   $
??Left=?64   $??122,196,0,0q?6O   $	??Top=?6d   ?? 5(   
   $
??Left=?6   $??23??6-   $??185,199,0,0q?69   $
 Wrap=?6N   $	??Top=?6c   $	??237??6{   .??6?   .??5)      ?? $ Phone?6   $ PropertyChanged=?6#    .  5*        5+      5-      5.      ?? 50   
   -   5        $ emailBox??50       $??
Почта??6   $
??Left=?62   $??122,236,0,0q?6M   $	??Top=?6b   ?? 51   
   $
??Left=?6   $??23??6-   $??185,239,0,0q?69   $
 Wrap=?6N   $	??Top=?6c   $	??237??6{   .??6?   .??52      ?? $ Email?6   $ PropertyChanged=?6#    .  53        54      56      57      ?? 5:   
   $*??$Зарегистрироваться??6,   $
??Left=?6I   $??213,341,0,0q?6d   $	??Top=?6y   $	??136??6?   $??35??6?   ??6   ?? *SignUp+6?   G? 5<   
   -   5         G?Name$ passwordBox??5<   D   $
??Left=?6Y   $??185,158,0,0q?6t   $	??Top=?6?   $	??237??6?   $??26??6?   ?? 5=   
   $??Пароль??6   $
??Left=?6!   $??122,158,0,0q?6<   $	??Top=?6Q   5?      5@      