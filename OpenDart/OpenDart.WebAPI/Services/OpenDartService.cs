using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenDart.WebAPI.Services
{
    public class OpenDartService
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public OpenDartService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("https://opendart.fss.or.kr/api/");
            this.client.DefaultRequestHeaders.Add("User-Agent", "OpenDart.WebAPI/1.0.0");
            this.configuration = configuration;
        }

        public string QueryString => $"?crtfc_key={configuration["APIKey"]}";

        /// <summary>
        /// https://opendart.fss.or.kr/api/corpCode.xml?crtfc_key=abc
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RequestCorporation()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"corpCode.xml{QueryString}");
            var response = await client.SendAsync(request);
            return response;
        }
    }
}
