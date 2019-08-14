using System;
using System.Collections.Generic;
using AppTarefa.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTarefa.Telas
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM");
            CarregarTarefas();
        }

        public void ActionGoCadastro(Object sender, EventArgs args)
        {
            Navigation.PushAsync(new AppTarefa.Telas.Cadastro());
        }

        private void CarregarTarefas()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> Lista = new GerenciadorTarefas().Listagem();

            foreach(Tarefa tarefa in Lista)
            {
                LinhaStackLayout(tarefa);
            }
        }

        public void LinhaStackLayout(Tarefa tarefa)
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = "Delete.png" };
            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = tarefa.Prioridade + ".png" };

            View StackCentral = null;
            if (tarefa.DataFinalizacao == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                StackCentral = new StackLayout() { Spacing = 0, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray});
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizado em" + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyy - hh:mm") + "h", TextColor = Color.Gray, FontSize = 10 });
            }

            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = "CheckOff.png" };
            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(Check);
            Linha.Children.Add(StackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
        }
    }
}
