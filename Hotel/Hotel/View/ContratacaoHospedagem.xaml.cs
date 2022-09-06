using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hotel.Model;

namespace Hotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContratacaoHospedagem : ContentPage
    {
        
        public ContratacaoHospedagem()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            lbl_usuario.Text = App.Current.Properties["usuario_logado"].ToString();

            pck_suite.ItemsSource = App.lista_suites;
            
            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddDays(1).AddMonths(6);
        }

        private void dtpck_checkin_selected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            dtpck_checkout.MinimumDate = elemento.Date.AddDays(1);
            dtpck_checkout.MaximumDate = elemento.Date.AddDays(1).AddMonths(6);
        }

        private void Button_Clicked(object sender, DateChangedEventArgs e)
        {
            try
            {
                Navigation.PushAsync(new HospedagemCalculada()
                {
                    BindingContext = new Hospedagem()
                    {
                        qnt_adultos = Convert.ToInt32(lbl_qnt_adultos.Text),
                        qntcriancas = Convert.ToInt32(lbl_qnt_criancas.Text),
                        QuartoEscolhido = (Suite)pck_suite.SelectedItem,
                        DatacheckIn = dtpck_checkin.Date,
                        datacheckOut = dtpck_checkout.Date
                    }
                });
            }
            catch(Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool confirme = await DisplayAlert("Tem Certeza?","Desconectar sua conta?", "SIM", "NÃO");
            if (confirme)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }
        }
    }
}