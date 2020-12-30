using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenDart.Model;
using OpenDart.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenDart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> logger;
        private readonly HttpService httpService;
        private readonly DatabaseService databaseService;

        public CompanyController(ILogger<CompanyController> logger, HttpService httpService, DatabaseService databaseService)
        {
            this.logger = logger;
            this.httpService = httpService;
            this.databaseService = databaseService;
        }

        // GET: api/<CompanyController>/00126380
        [HttpGet("{corporationCode}")]
        public async Task<Company> Get(string corporationCode)
        {
            if (string.IsNullOrWhiteSpace(corporationCode) || 
                corporationCode.Length != 8)
            {
                // TODO: Exception
                throw new ArgumentNullException(nameof(corporationCode));
            }

            Company result = null;

            try
            {
                if (await databaseService.IsEmptyCompany(corporationCode))
                {
                    var response = await httpService.RequestCompany(corporationCode);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        result = JsonSerializer.Deserialize<Company>(responseString);

                        await databaseService.InsertCompany(result);
                    }
                }
                else
                {
                    result = await databaseService.GetCompany(corporationCode);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            // Returns "204 - No Content" if null.
            return result;
        }
    }
}
