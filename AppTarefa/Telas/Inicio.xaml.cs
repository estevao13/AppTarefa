using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppTarefa.Telas
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }

        public void ActionGoCadastro (Object sender, EventArgs args)
        {
            Navigation.PushAsync(new AppTarefa.Telas.Cadastro());
        }
    }
}
