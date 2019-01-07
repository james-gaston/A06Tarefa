using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A06Tarefa.Modelos;

namespace A06Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        private byte Prioridade { get; set; }

        public Cadastro ()
		{
			InitializeComponent ();
            txtNome.Text = "";
        }

        public void PrioridadeSelect(object sender, EventArgs args)
        {
            Label Selecionado = (Label)((StackLayout)sender).Children[1];
            TapGestureRecognizer Tap = ((StackLayout)sender).GestureRecognizers[0] as TapGestureRecognizer;
            var Stacks = SLPrioridades.Children;
            foreach (StackLayout Linha in Stacks)
            {
                Label lblPrioridade = Linha.Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            Selecionado.TextColor = Color.Black;

            Prioridade = byte.Parse(Tap.CommandParameter.ToString());
        }

        public void Salvar(object sender, EventArgs args)
        {
            bool Erro = false;
            if (!(txtNome.Text.Trim().Length > 0))
            {
                DisplayAlert("ERRO", "Nome não preenchido!","OK");
                Erro = true;
            }
            
            if (!(Prioridade > 0))
            {
                DisplayAlert("ERRO", "Prioridade não informada!", "OK");
                Erro = true;
            }

            if (!Erro)
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = txtNome.Text.Trim();
                tarefa.Prioridade = Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());
            }

        }

    }
}