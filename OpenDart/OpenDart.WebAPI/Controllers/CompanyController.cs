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
        private readonly OpenDartService openDartService;

        public CompanyController(ILogger<CompanyController> logger, OpenDartService openDartService)
        {
            this.logger = logger;
            this.openDartService = openDartService;
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
                // TODO: Check the cache and returns if exist

                var response = await openDartService.RequestCompany(corporationCode);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Company>(responseString);
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
