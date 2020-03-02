using System;
using System.Collections.Generic;
using System.Text;
using App3_ConsultarCEP_3.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;

namespace App3_ConsultarCEP_3.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null ;

            return end;

        }
    }
}
