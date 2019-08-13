using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppTarefa.Telas
{
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        public void PrioridadeSelectAction(Object sender, EventArgs args)
        {
            var Stacks = SLPrioridades.Children;

            foreach(var Linha in Stacks)
            {
                Label LblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                LblPrioridade.TextColor = Color.LightGray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.DarkGray;
        }
    }
}
