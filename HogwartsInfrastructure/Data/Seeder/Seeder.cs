using HogwartsCore.Entities;
using HogwartsCore.Models;
using HogwartsCore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsInfrastructure.Data.Seeder
{
    public class Seeder : ISeeder
    {
        private readonly HogwartsContext context;
        private readonly IAppLogger<Seeder> logger;
        private readonly IHostingEnvironment hosting;
        private IDictionary<string, object> dictionaryJsonFile;
        private PathData pathData { get; }
        private readonly bool dbReset;
        private readonly bool dbPopulate;


        public Seeder(HogwartsContext context,
                      IAppLogger<Seeder> logger,
                      IOptions<PathData> pathData,
                      IHostingEnvironment hosting,
                      IConfiguration configuration)
        {
            this.logger = logger;
            this.context = context;
            this.pathData = pathData.Value;
            this.dbReset = configuration.GetValue<bool>("ResetDatabase");
            this.dbPopulate = configuration.GetValue<bool>("PopulateDatabase");
            this.hosting = hosting;
        }

        public async Task SeedPopulate()
        {
            try
            {
                await context.Database.MigrateAsync();
                await PopulateData();

                logger.LogWarning($"Database is create");
            }
            catch (Exception ex)
            {
                logger.LogWarning($"{ex.Message}, {ex.InnerException.Message} {ex.StackTrace}");
                throw new Exception(ex.Message);
            }
        }

        private async Task PopulateData()
        {
            if (dbPopulate || dbReset)
            {
                dictionaryJsonFile = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (File.ReadAllText(Path.Combine(hosting.ContentRootPath, pathData.PathDataDB)));

                if (!context.Fraternity.Any()) await PopulateData<Fraternity>(nameof(Fraternity));
            }
        }

        private async Task PopulateData<TEntity>(string entityName) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();

            if (!dbSet.Any())
            {
                if (dictionaryJsonFile.ContainsKey(entityName))
                {
                    try
                    {
                        logger.LogInformation($"Filling the table: {entityName}");
                        IEnumerable<TEntity> listItems = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(dictionaryJsonFile[entityName].ToString());
                        await dbSet.AddRangeAsync(listItems);
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogWarning($"{ex.Message}, {ex.InnerException.Message} {ex.StackTrace}");
                        throw new Exception(ex.Message);
                    }

                }
            }
        }
    }
}
