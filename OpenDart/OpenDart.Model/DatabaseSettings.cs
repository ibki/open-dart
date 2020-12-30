using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDart.Model
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CorporationsCollectionName { get; set; }
        public string CompaniesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDatabaseSettings
    {
        string CorporationsCollectionName { get; set; }
        string CompaniesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
