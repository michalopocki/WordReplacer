   M S B A M L   `   `   `  ???? J  FWordReplacerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WordReplacerAppWordReplacerApp  G(clr-namespace:WordReplacerApp.PropertiesWordReplacerApp.Properties       WordReplacerApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WordReplacerApp     R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  7language(clr-namespace:WordReplacerApp.Properties  $  MvvmDialogs.DialogServiceViews    IsRegistered  .  ? Title$ Word Replacer??$	??450??$	??800?? ? DataContext ??  ?? Path$ MainViewModel?   ViewModelLocator ?? Source# [   ? 	Resources   ListViewStyle ?? 
TargetType ?? Property ?? Value  stopBtn	 ?? Triggers
 ?? Binding ?? ElementName ?? Value??%?   &	       &	 %     ?? " ??.???  ? ??$
 Left=??? " ??.???  ? ??$
 Stop????  ? y?$ Visible=?	 ?? 
 ?? $ progressBar??$ Value? 100.a???  ? y?$ Hidden=?.???  ? RowDefinitions ?? $??* ??? $??25 ?.+?? $??0?? ? ColumnDefinitions ?? $??* ??? $??* ?.+?? $??0?? ?? $??40 ??? $??* ?.+???  ?? Orientation$ 
Horizontal=?.+??? %   WordReplacerApp.Properties.Lang   addFiles#??Z $	??100??$??10q?$
??Left=????? *	AddFile+ ?? Mode$ OneWay=???    removeSelectedFile#??Z $	??100??$??10q?$
??Left=?$??single?????? *
DeleteFile+$ OneWay=???    removeAllFiles#??Z $	??100??$??10q?$
??Left=?$	??all?????? *
DeleteFile+$ OneWay=??? $??1??$
??Auto=?$??Disabled=?.???? $??10q?$??Stretch=?$
??Left=? ?? SelectionMode$ Single=? ?? SelectedIndex$ 0?????? *DocumentList+ ?? SelectedItem ?? *SelectedDocument+$ OneWayToSource=? ?? View ?? .P???  ?? HeaderContainerStyle# [ $??Nazwa pliku?? ?? Width$	 120?? ?? DisplayMemberBinding ?? *
FileName+?? # [ $??	Ścieżka??$	 200?? ?? *
FullPath+? $??1?? ?? $??40 ??? $??60 ??? $??* ??? $??90 ?.+??? $??0??$ 
Horizontal=?.+???    
addReplace#??Z $	??100??$??10q?$
??Left=?$	??Add?????? *UpdateListBox+??    removeReplace#??Z $	??100??$??10q?$
??Left=?$??Delete?????? *UpdateListBox+?? $??1??$??2q?$??1q?
???   ????? -    ??Name$ dateCheckBox??   replaceDate#??Z $??2,0,2,0q? d? 	IsChecked ?? *
DateChange+$ TwoWay=?.??? {??? $ dateCheckBox??$ 	IsChecked?.+??? $ 
Horizontal=?.+???     replaceDateTo#??Z  $??5q?$??Center=?(  "System.Windows.Controls.DatePicker  $??5q?$??Center=?!   SelectedDate! ?? *SelectedDate+$ TwoWay=??? $??2??$ Single=?$??3q????? *ReplaceTextList+ ?? *SelectedItem+???? .R??? " K? IsItemsHost" . ???? .R?? 
????ح?$	??350??.+??? $??1q?
???   ?._??  ?? $??* ??? $??3* ?.+??? $??0??$??5q?.+??? #   textFrom#??Z# $??5q??? $   textTo#??Z$ $??5q??? $??1??$??5q?.+??? $??5q????? *
FromText+$ TwoWay=??? $??5q????? *ToText+$ TwoWay=??? $??3??.+??? $??1q?
???   ?$??40??$??5q?._??  ?? $??93 ??? $??3* ??? $	??100 ?.+??? $??0??%   
saveFolder#??Z% $??10q??? $??1??$??10q?$
??Bold"?$??Right=????? *
SavePath+$ OneWay=??? $??2??&   changeFolder#??Z& $??8q????? *ChangeSavePath+?? $	??100??$??30??'   execute#??Z' $??5q????? *FindAndReplace+?? $??1??$??Center=?$??Center=?.@?? -   ( ?Name$( progressBar??) ? Minimum$) 0Q?* ? Maximum$	* 100Q?$	??500??$??20?????	#FFB6BABA+ ? Value+ ?? *ProgressBarValue+$ OneWay=??? ?? ??? *ProgressBarValue+$ OneWay=? ?? $?%???? $??50??$
??Stop??
???  ??#??[ ???? *StopProcessing+