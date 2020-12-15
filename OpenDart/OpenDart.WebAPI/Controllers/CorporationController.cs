using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenDart.Model;
using OpenDart.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenDart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporationController : ControllerBase
    {
        private readonly ILogger<CorporationController> logger;
        private readonly IConfiguration configuration;
        private readonly OpenDartService openDartService;

        public CorporationController(ILogger<CorporationController> logger, IConfiguration configuration, OpenDartService openDartService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.openDartService = openDartService;
        }

        // GET: api/<CorporationController>
        [HttpGet]
        public async Task<IEnumerable<Corporation>> Get()
        {
            List<Corporation> result = null;

            try
            {
                var response = await openDartService.RequestCorporation();
                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    using var archive = new ZipArchive(responseStream, ZipArchiveMode.Read, true, Encoding.UTF8);
                    var entry = archive.Entries.FirstOrDefault();
                    if (entry != null)
                    {
                        using var unzippedEntryStream = entry.Open();
                        var serializer = new XmlSerializer(typeof(CorporationList));
                        result = (serializer.Deserialize(unzippedEntryStream) as CorporationList).Corporations;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return result;
        }
    }
}
