using System.Threading.Tasks;
using SchoolManager.Entities;

namespace SchoolManager.Repositories
{
    public interface IStudentRepository {
        Task AddAsync(Student student);
    }
}