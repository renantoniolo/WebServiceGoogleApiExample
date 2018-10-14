using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServiceGoogleApiExample.Model;
using WebServiceGoogleApiExample.Utils;

namespace WebServiceGoogleApiExample.Servico
{
    public abstract class BaseHTTPService
    {
        // chave para acesso ao google
        private static string keyGoogleAPI = "AIzaSyCsSg7bz_6IRuSrh8DxZr7Dld8rLJD5c3M";

        public static async Task<PleaceAutoComplete> GetPlaceAutocomplete(string cidade)
        {
            PleaceAutoComplete result = new PleaceAutoComplete();

            HttpResponseMessage response = await HttpUtil.GetAsync("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + cidade + "&types=(cities)&language=pt_BR&key=" + keyGoogleAPI);

            switch ((int)response.StatusCode)
            {
                case 200:
                    result = JsonConvert.DeserializeObject<PleaceAutoComplete>(response.Content.ReadAsStringAsync().Result);
                    break;
                case 400:
                    var obj = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result);

                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

    }
}
