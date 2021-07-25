using System.Threading.Tasks;
using SchoolManager.Entities;

namespace SchoolManager.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task AddAsync(Student student)
        {
            return Task.CompletedTask;
        }
    }
}