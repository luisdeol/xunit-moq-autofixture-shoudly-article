using System;
using System.Threading.Tasks;

namespace SchoolManager.IntegrationServices
{
    public class ErpIntegrationService : IErpIntegrationService
    {
        public Task<bool> SyncStudent(ErpStudent student)
        {
            var randomNumber = new Random().Next(100);

            return Task.FromResult(randomNumber % 2 == 0);
        }
    }
}