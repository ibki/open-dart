using MongoDB.Driver;
using OpenDart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDart.WebAPI.Services
{
    public class DatabaseService
    {
        private readonly IMongoCollection<Company> companies;
        private readonly IMongoCollection<Corporation> corporations;

        public DatabaseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            companies = database.GetCollection<Company>(settings.CompaniesCollectionName);
            corporations = database.GetCollection<Corporation>(settings.CorporationsCollectionName);
        }

        #region Corporation

        public async Task<bool> IsEmptyCorporation()
            => (await corporations.Find(corporation => true).AnyAsync()) == false;

        public async Task<List<Corporation>> GetCorporations()
            => await corporations.Find(corporation => true).ToListAsync();

        public async Task<Corporation> GetCorporation(string code) 
            => await corporations.Find<Corporation>(corporations => corporations.Code == code).FirstOrDefaultAsync();

        public async Task<List<Corporation>> InsertCorporations(IEnumerable<Corporation> corporations)
        {
            await this.corporations.InsertManyAsync(corporations);

            return await GetCorporations();
        }

        #endregion

        #region Company

        public async Task<bool> IsEmptyCompany(string corporationCode)
            => await companies.Find<Company>(companies => companies.CorporationCode == corporationCode).AnyAsync() == false;

        public async Task<Company> GetCompany(string corporationCode)
            => await companies.Find<Company>(companies => companies.CorporationCode == corporationCode).FirstOrDefaultAsync();

        public async Task InsertCompany(Company company)
            => await companies.InsertOneAsync(company);

        #endregion
    }
}
