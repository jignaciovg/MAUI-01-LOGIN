using App01Login.Helpers;
using App01Login.Interfaces;
using App01Login.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App01Login.Services
{
    public class CiudadService:ICiudad
    {
        System.Net.Http.HttpClient client;
        string WebAPIUrl = string.Empty;
        public CiudadService()
        {
            client = new System.Net.Http.HttpClient();
        }

        public async Task<List<Ciudad>> GetAuthCiudadesAsync(string token)
        {
            await Task.Delay(1000);
            WebAPIUrl = "http://192.168.1.72/api/Ciudad/getAuth";
            var uri = new Uri(WebAPIUrl);
            try
            {
                HttpContent _content = new StringContent(JsonConvert.SerializeObject(token));
                _content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(uri, _content);

                if (response.IsSuccessStatusCode)
                {
                    Ciudad _ciudad = new Ciudad();
                    var content = await response.Content.ReadAsStringAsync();
                    _ciudad = (Ciudad)JsonConvert.DeserializeObject(content);
                    List<Ciudad> ListaCiudad = new List<Ciudad>();
                    for (int i = 0; i < content.Length; i++)
                    {
                        ListaCiudad.Add(new Ciudad()
                        {
                            Nombre = _ciudad.Nombre,
                            Estado = _ciudad.Estado,
                            Cp = _ciudad.Cp,
                        });
                        return ListaCiudad;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        
    }
}
