# AtividadeCSharp
# AtividadeCSharp


Problema com a utilização do new


string[] recebeDados = { Convert.ToString(dtg_TabelaEndereco.SelectedItems) };
int posicaoPontoVirgula = recebeDados[0].IndexOf(";");

recebeDados[1].Substring(0, posicaoPontoVirgula);
recebeDados[0] = recebeDados[0].Remove(0, posicaoPontoVirgula);

recebeDados[2].Substring(0, posicaoPontoVirgula);
recebeDados[0] = recebeDados[0].Remove(0, posicaoPontoVirgula);

recebeDados[3].Substring(0, posicaoPontoVirgula);
recebeDados[0] = recebeDados[0].Remove(0, posicaoPontoVirgula);

recebeDados[4].Substring(0, posicaoPontoVirgula);
recebeDados[0] = recebeDados[0].Remove(0, posicaoPontoVirgula);

recebeDados[5].Substring(0, posicaoPontoVirgula);
recebeDados[0] = recebeDados[0].Remove(0, posicaoPontoVirgula);

recebeDados[6].Substring(0, posicaoPontoVirgula);
recebeDados[0] = recebeDados[0].Remove(0, posicaoPontoVirgula);



//controller.receberDadosTabelaEndereco(logradouro, numero, complemento, bairro, cidade, estado);

btn_excluir.IsEnabled = true;