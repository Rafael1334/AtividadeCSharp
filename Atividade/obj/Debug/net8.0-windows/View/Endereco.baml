   M S B A M L   `   `   `  ����D  @Atividade, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Atividade.ViewAtividade.View  5          Atividade.View.Endereco   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Atividade.View     5        N� Title$  Endereco��5	      .��5      � .+�5   
   �� $��Logradouro:��6   $
��Left=�6&   $��	41,67,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        $��txt_Logradouro��5      $
��Left=�6(   $��	41,92,0,0q�6C   $	��Top=�6V   $	��175��6n   �� 5   
   $��Número:��6   $
��Left=�6"   $��
41,142,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5        $��
txt_Numero��5      $
��Left=�6$   $��
41,167,0,0q�6?   $	��Top=�6S   $	��175��6k   6w   �� 5   
   $��Complemento:��6   $
��Left=�6'   $��
41,217,0,0q�6B   $	��Top=�6V   �� 5   
   -   5        $��txt_Complemento��5      $
��Left=�6)   $��
41,242,0,0q�6D   $	��Top=�6X   $	��175��6p   �� 5   
   $��Bairro:��6   $
��Left=�6"   $��
41,292,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5        $��
txt_Bairro��5      $
��Left=�6$   $��
41,317,0,0q�6?   $	��Top=�6S   $	��175��6k   �� 5   
   $��Cidade:��6   $
��Left=�6"   $��
259,67,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5        $��
txt_Cidade��5      $
��Left=�6$   $��
259,92,0,0q�6?   $	��Top=�6S   $	��175��6k   �� 5   
   $��Estado:��6   $
��Left=�6"   $��259,142,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $��	cb_Estado��5      $
��Left=�6$   $��259,167,0,0q�6?   $	��Top=�6T   $	��175��6l    �� SelectedIndex$ 0��6x   ��6�   �� *EstadosBrasileiros+&   System.Windows.Controls.DataGrid  5   
   -   5        $��dtg_TabelaEndereco��5      $	��300��6.   $	��400��6;   $��
470,67,0,0q�6G   $	��Top=�6[   $
��Left=�5          AutoGenerateColumns$
 True��6.      CanUserAddRows$ False��5!         CanUserDeleteRows$
 True��6*   �� 5#   
   -   5        $��btn_adicionarEndereco��5#      $��	Adicionar��6/   $
��Left=�6C   $��380,317,0,0q�6^   $	��Top=�6s   6�   �� 5%   
   -	   5        $��btn_proximo��5%      $��Proximo��6$   $
��Left=�66   $��722,420,0,0q�6Q   $	��Top=�6f   ${�false��6�   �� 5'   
   -
   5        $��
btn_voltar��5'      $��Voltar��6#   $
��Left=�64   $��
41,420,0,0q�6O   $	��Top=�6c   6{   �� 5)   
   -   5        $��btn_excluir��5)      $��Excluir��6$   $
��Left=�66   $��470,381,0,0q�6Q   $	��Top=�6f   ${�false��6�   5-      5.      