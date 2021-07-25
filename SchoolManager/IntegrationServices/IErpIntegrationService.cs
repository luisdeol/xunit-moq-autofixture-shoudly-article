using System.Threading.Tasks;

namespace SchoolManager.IntegrationServices
{
    public interface IErpIntegrationService
    {
        Task<bool> SyncStudent(ErpStudent student);
    }
}