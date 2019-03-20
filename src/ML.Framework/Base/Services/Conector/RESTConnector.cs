using ML.Framework.Base.Servicos.Conector.Interface;
using ML.Framework.Base.Servicos.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ML.Framework.Base.Servicos.Conector
{
    public class RestConnector : IRestConnector
    {
        private const int SECONDS_TO_TIMEOUT = 15;

        private static HttpClient _cliente { get; } = GetClientInstance();

        private static HttpClient GetClientInstance()
        {
            var _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(SECONDS_TO_TIMEOUT)
            };
            return _httpClient;
        }


        public async Task<Result<string>> GetJson(string url)
        {
            try
            {
                var response = await _cliente.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return ResultHelper.MakeErrorMessage<string>(response.StatusCode.ToString(), response.ReasonPhrase);

                var responseContent = await response.Content.ReadAsStringAsync();
                return ResultHelper.MakeResponseContentMessage<string>(responseContent);
            }
            catch (Exception e)
            {
                return ResultHelper.MakeExceptionMessage<string>(e);
            }
        }

        public async Task<Result<string>> PostJson(string url, string json)
        {
            try
            {
                var conteudoDaRequisicao = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _cliente.PostAsync(url, conteudoDaRequisicao);

                if (!response.IsSuccessStatusCode)
                    return ResultHelper.MakeErrorMessage<string>(response.StatusCode.ToString(), response.ReasonPhrase);

                var responseContent = await response.Content.ReadAsStringAsync();
                return ResultHelper.MakeResponseContentMessage<string>(responseContent);
            }
            catch (Exception e)
            {
                return ResultHelper.MakeExceptionMessage<string>(e);
            }
        }

    }
}
