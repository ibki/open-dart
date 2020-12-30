using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenDart.Model;
using OpenDart.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenDart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporationController : ControllerBase
    {
        private readonly ILogger<CorporationController> logger;
        private readonly HttpService httpService;
        private readonly DatabaseService databaseService;

        public CorporationController(ILogger<CorporationController> logger, HttpService httpService, DatabaseService databaseService)
        {
            this.logger = logger;
            this.httpService = httpService;
            this.databaseService = databaseService;
        }

        // GET: api/<CorporationController>
        [HttpGet]
        public async Task<IEnumerable<Corporation>> Get()
        {
            List<Corporation> result = null;

            try
            {
                if (await databaseService.IsEmptyCorporation())
                {
                    var response = await httpService.RequestCorporation();
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

                            await databaseService.InsertCorporations(result);
                        }
                    }
                }
                else
                {
                    result = new List<Corporation>(await databaseService.GetCorporations());
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
