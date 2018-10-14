using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebServiceGoogleApiExample.Model;
using WebServiceGoogleApiExample.Servico;
using Xamarin.Forms;

namespace WebServiceGoogleApiExample.View
{
    public partial class ListAddressPage : ContentPage
    {
        public ListAddressPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // inicia como oculto
            xload.IsVisible = false;
        }

        async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                List<string> ListCidades = new List<string>();

                xload.IsVisible = true;

                if (e.NewTextValue.Length > 2)
                {
                    PleaceAutoComplete pleaceAutoComplete = await BaseHTTPService.GetPlaceAutocomplete(e.NewTextValue);

                    foreach (var cidade in pleaceAutoComplete.Predictions)
                    {
                        ListCidades.Add(cidade.Description);
                    }

                    ListAddress.ItemsSource = ListCidades;

                }

            }
            catch(Exception ex){
                Debug.WriteLine(ex.Message);
            }
            finally{
                xload.IsVisible = false;
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(xSearch.Text))
                {
                    xload.IsVisible = true;

                    PleaceAutoComplete pleaceAutoComplete = await BaseHTTPService.GetPlaceAutocomplete(xSearch.Text);

                    List<string> ListCidades = new List<string>();

                    foreach (var cidade in pleaceAutoComplete.Predictions)
                    {
                        ListCidades.Add(cidade.Description);
                    }

                    ListAddress.ItemsSource = ListCidades;
                }

            }
            catch(Exception ex){
                Debug.WriteLine("Error:" + ex.Message);
            }
            finally{
                xload.IsVisible = false;
            }
        }
    }
}
