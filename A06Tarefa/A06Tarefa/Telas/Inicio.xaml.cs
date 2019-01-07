using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A06Tarefa.Modelos;
using A06Tarefa.Stacks;
using System.Globalization;

namespace A06Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	 public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();

            CultureInfo culture = new CultureInfo("pt-BR");
            string Data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture);
            
            DataHoje.Text = string.Format(Data, "de");
            LinhaStackLayout();
		}

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        public void LinhaStackLayout()
        {
            SLTarefas.Children.Clear();
            int index = 0;
            foreach (var tarefa in new GerenciadorTarefa().Listar())
            {
                if (tarefa.Finalizacao == null) SLTarefas.Children.Add(new ViewOff(tarefa, index));
                else SLTarefas.Children.Add(new ViewOn(tarefa, index));
                index++;
            }
        }

    }
}