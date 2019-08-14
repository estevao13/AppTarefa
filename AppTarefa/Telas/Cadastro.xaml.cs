using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using AppTarefa.Modelos;


namespace AppTarefa.Telas
{
    public partial class Cadastro : ContentPage
    {
        private byte Prioridade { get; set; }
        public Cadastro()
        {
            InitializeComponent();
        }

        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var Stacks = SLPrioridades.Children;

            foreach (var Linha in Stacks)
            {
                Label LblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                LblPrioridade.TextColor = Color.LightGray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            String Prioridade = Source.File.ToString().Replace(".png", "").Replace("p", "");

            this.Prioridade = byte.Parse(Prioridade);
        }

        public void SalvarAction(Object sender, EventArgs args)
        {
            bool ErroExiste = false;

            if (!(TxtNome.Text.Trim().Length > 0))
            {
                ErroExiste = true;
                DisplayAlert("ERRO", "Nome não preencido", "OK");
            }

            if (!(this.Prioridade > 0))
            {
                ErroExiste = true;
                DisplayAlert("ERRO", "A prioridade não informado", "OK");

            }

            if (ErroExiste == false)
            {
             
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = TxtNome.Text.Trim();
                tarefa.Prioridade = this.Prioridade;

                //new GerenciadorTarefa().Salvar(tarefa);

                new GerenciadorTarefas().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}
