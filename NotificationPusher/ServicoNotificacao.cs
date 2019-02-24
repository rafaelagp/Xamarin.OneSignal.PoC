using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NotificationPusher
{
    public static class ServicoNotificacao
    {
        const string APP_ID = "";

        public static async Task EnviarNotificacaoLogoutAsync(string cpf, string deviceId)
        {
            try
            {
                await EnviarNotificacaoAsync(JsonConvert.SerializeObject(new
                {
                    app_id = APP_ID,
                    content_available = "true",
                    filters = new object[]
                    {
                        new { field = "tag", key = "cpf", relation = "=", value = cpf },
                        new { @operator = "AND" },
                        new { field = "tag", key = "device_id", relation = "!=", value = deviceId }
                    },
                    data = new
                    {
                        shouldLogout = "true"
                    } 
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static async Task EnviarNotificacaoAtualizacaoPorCpfAsync(string cpf)
        {
            try
            {
                await EnviarNotificacaoAsync(JsonConvert.SerializeObject(new
                {
                    app_id = APP_ID,
                    content_available = "true",
                    filters = new object[]
                    {
                        new { field = "tag", key = "cpf", relation = "=", value = cpf }
                    },
                    data = new
                    {
                        refreshDb = "true"
                    } 
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static async Task EnviarNotificacaoAtualizacaoPorCargoAsync(string cargo)
        {
            try
            {
                await EnviarNotificacaoAsync(JsonConvert.SerializeObject(new
                {
                    app_id = APP_ID,
                    content_available = "true",
                    filters = new object[]
                    {
                        new { field = "tag", key = "cargo_id", relation = "=", value = cargo }
                    },
                    data = new
                    {
                        refreshDb = "true"
                    }
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static async Task EnviarNotificacaoAsync(string corpo)
        {
            using (var cli = new HttpClient())
            {
                cli.DefaultRequestHeaders
                   .Add("Authorization", 
                        "Basic ");

                var resposta = 
                    await cli.PostAsync("https://onesignal.com/api/v1/notifications", 
                                        new StringContent(corpo, 
                                                          Encoding.UTF8, 
                                                          "application/json"));
                if (!resposta.IsSuccessStatusCode)
                    Debug.WriteLine(await resposta.Content.ReadAsStringAsync());
            }
        }
    }
}
