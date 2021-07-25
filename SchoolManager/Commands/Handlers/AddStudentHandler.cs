using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SchoolManager.IntegrationServices;
using SchoolManager.Repositories;

namespace SchoolManager.Commands.Handlers
{
    public class AddStudentHandler : IRequestHandler<AddStudent, AddStudentViewModel>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IErpIntegrationService _erpIntegrationService;
        public AddStudentHandler(IStudentRepository studentRepository, IErpIntegrationService erpIntegrationService)
        {
            _studentRepository = studentRepository;
            _erpIntegrationService = erpIntegrationService;
        }

        public async Task<AddStudentViewModel> Handle(AddStudent request, CancellationToken cancellationToken)
        {
            var student = request.ToEntity();

            await _studentRepository.AddAsync(student);

            var erpStudent = ErpStudent.FromEntity(student);
            await _erpIntegrationService.SyncStudent(erpStudent);

            return AddStudentViewModel.FromEntity(student);
        }
    }
}