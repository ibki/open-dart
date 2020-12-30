using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenDart.WebAPI.Services
{
    public class HttpService
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public HttpService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("https://opendart.fss.or.kr/api/");
            this.client.DefaultRequestHeaders.Add("User-Agent", "OpenDart.WebAPI/1.0.0");
            this.configuration = configuration;
        }

        public string DefaultQueryString => $"?crtfc_key={configuration["APIKey"]}";

        /// <summary>
        /// https://opendart.fss.or.kr/api/corpCode.xml?crtfc_key=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RequestCorporation()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"corpCode.xml{DefaultQueryString}");
            var response = await client.SendAsync(request);
            return response;
        }

        /// <summary>
        /// https://opendart.fss.or.kr/api/company.json?crtfc_key=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx&corp_code=00126380
        /// </summary>
        /// <param name="corporationCode"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RequestCompany(string corporationCode)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"company.json{DefaultQueryString}&corp_code={corporationCode}");

            var response = await client.SendAsync(request);

            return response;
        }
    }
}
