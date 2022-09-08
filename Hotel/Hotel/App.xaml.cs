using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Threading;
using System.Globalization;

using Hotel.Model;

namespace Hotel
{
    public partial class App : Application
    {
        public static List<Suite> lista_suites = new List<Suite>
        {
            new Suite()
            {
                Nome = "Super Luxo",
                DiariaAdulto = 110.0,
                DiariaCrianca = 55.0
            },
            new Suite()
            {
                Nome = "Executiva",
                DiariaCrianca = 45.0,
                DiariaAdulto = 90.0
            },
            new Suite()
            {
                Nome = "Normal",
                DiariaAdulto = 45.0,
                DiariaCrianca = 20.0
            }
        };

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            InitializeComponent();


            if (Properties.ContainsKey("usuario_logado"))
                MainPage = new NavigationPage(new View.ContratacaoHospedagem());
            else
                MainPage = new View.Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
