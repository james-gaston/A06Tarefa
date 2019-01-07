using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A06Tarefa.Modelos;
using A06Tarefa.Telas;

namespace A06Tarefa.Stacks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewOff : ContentView
	{
        public ImageSource img1;
        public ImageSource img2;
        public Tarefa t;
        public int n;

        public ViewOff (Tarefa tarefa, int nn)
		{
			InitializeComponent ();
            t = tarefa;
            lblName.Text = t.Nome;
            img1 = "p" + t.Prioridade + ".png";
            img2 = "Resources/p" + t.Prioridade + ".png";
            if (Device.RuntimePlatform == Device.UWP) imgP.Source = img2;
            else imgP.Source = img1;
            n = nn;
        }

        public void DeletarTap(object sender, EventArgs args)
        {
            new GerenciadorTarefa().Deletar(n);
            App.Current.MainPage = new NavigationPage(new Inicio());
        }

        public void CheckTap(object sender, EventArgs args)
        {
            new GerenciadorTarefa().Finalizar(t,n);
            App.Current.MainPage = new NavigationPage(new Inicio());
        }
    }
}