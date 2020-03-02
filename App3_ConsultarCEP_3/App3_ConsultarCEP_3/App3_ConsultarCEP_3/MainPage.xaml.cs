using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3_ConsultarCEP_3.Servico.Modelo;
using App3_ConsultarCEP_3.Servico;

namespace App3_ConsultarCEP_3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        //TODO - Lógica do programa
        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

                if (isValidCEP(cep))
                {
                    try
                    {
                        Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ÊRRO", "Endereço não encontrado para o cep informado: " + cep, "OK");
                    }
                    }

                    catch(Exception e)
                    {
                    DisplayAlert("ÊRRO CRÍTICO", e.Message, "OK");
                    }
                }
        }
                        

        //TODO - Validações
        private bool isValidCEP(string cep) 
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ÊRRO","CEP inválido. Deve conter 8 caractesres.","OK");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ÊRRO", "CEP inválido. Deve conter apenas números.", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
          
            

            


           
           
            

    

            


