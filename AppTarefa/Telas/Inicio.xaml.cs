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

            int i = 0;
            foreach (Tarefa tarefa in Lista)
            {
                LinhaStackLayout(tarefa, i);
                i++;
            }
        }

        public void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = "Delete.png" };

            TapGestureRecognizer DeleteTap = new TapGestureRecognizer();
            DeleteTap.Tapped += delegate
            {
                new GerenciadorTarefas().Deletar(index);
                CarregarTarefas();
            };
            Delete.GestureRecognizers.Add(DeleteTap);

            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = tarefa.Prioridade + ".png" };

            View StackCentral = null;
            if (tarefa.DataFinalizacao == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                StackCentral = new StackLayout() { Spacing = 0, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizado em " + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyy - hh:mm") + "h", TextColor = Color.Gray, FontSize = 10 });
            }

            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };

            if (tarefa.DataFinalizacao != null)
            {
                Check.Source = ImageSource.FromFile("CheckOn.png");
            }


            TapGestureRecognizer CheckTap = new TapGestureRecognizer();
            CheckTap.Tapped += delegate
            {
                new GerenciadorTarefas().Finalizar(index, tarefa);
                CarregarTarefas();
            };

            Check.GestureRecognizers.Add(CheckTap);

            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(Check);
            Linha.Children.Add(StackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
        }
    }
}
