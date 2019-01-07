using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace A06Tarefa.Modelos
{
    public class GerenciadorTarefa
    {

        private List<Tarefa> Lista { get; set; }

        public void Salvar(Tarefa tarefa)
        {
            Lista = Listar();

            Lista.Add(tarefa);

            SalvarDisco();
        }

        public void Deletar(int index)
        {
            Lista = Listar();

            Lista.RemoveAt(index);

            SalvarDisco();
        }

        public void Finalizar(Tarefa tarefa,int index)
        {
            Lista = Listar();
            Lista.RemoveAt(index);
            tarefa.Finalizacao = DateTime.Now;
            Lista.Add(tarefa);
            SalvarDisco();
        }

        public void Reabrir(Tarefa tarefa,int index)
        {
            Lista = Listar();
            Lista.RemoveAt(index);
            tarefa.Finalizacao = null;
            Lista.Add(tarefa);
            SalvarDisco();
        }


        public List<Tarefa> Listar()
        {
            return ListarDisco();
        }

        private void SalvarDisco()
        {
            if (App.Current.Properties.ContainsKey("Tarefas")) App.Current.Properties.Remove("Tarefas");
            string Jsonval = JsonConvert.SerializeObject(Lista);
            App.Current.Properties.Add("Tarefas", Jsonval);
        }

        private List<Tarefa> ListarDisco()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string Jsonval = (string)App.Current.Properties["Tarefas"];
                return JsonConvert.DeserializeObject<List<Tarefa>>(Jsonval);
            }
            return new List<Tarefa>();
        }

        public void DeletarTudo()
        {
            Lista = Listar();

            Lista = new List<Tarefa>();

            SalvarDisco();
        }
    }
}
