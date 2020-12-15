using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenDart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenDart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> logger;
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;

        public CompanyController(ILogger<CompanyController> logger, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.clientFactory = clientFactory;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return new Company[]
            {
                new Company { CorporationName = "삼성전자" }
            };
        }

        // GET: api/<CompanyController>/5
        [HttpGet("{corporationCode}")]
        public Company Get(string corporationCode)
        {
            if (string.IsNullOrWhiteSpace(corporationCode))
                throw new ArgumentNullException("");

            if (corporationCode.Length != 8)
                throw new ArgumentNullException("");

            return new Company { CorporationName = "삼성전자" };
        }
    }
}
