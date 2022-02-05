using App01Login.Helpers;
using App01Login.Interfaces;
using App01Login.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App01Login.Services
{
    internal class LoginService : ILogin
    {
        System.Net.Http.HttpClient _httpClient;
        string WebApiUrl = string.Empty;

        public LoginService()
        {
            _httpClient = new System.Net.Http.HttpClient();
        }

        public async Task<Login>Authenticate(UserMin userMin)
        {
            await Task.Delay(1000);
            userMin.Password = Functions.GetSHA256(userMin.Password).ToUpper();
            WebApiUrl = "http://189.254.239.133/LoginAppApi/api/login/autenticar";

            var uri = new Uri(WebApiUrl);
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(userMin));
                //Cabeceras
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Login login = new Login();
                    var usuarioLoged = await response.Content.ReadAsStringAsync();
                    login = JsonConvert.DeserializeObject<Login>(usuarioLoged);
                    return login;
                }
                return null;

            }catch (Exception)
            {
                return null;
            }
        }
    }
}
