using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using SchoolManager.Commands;
using SchoolManager.Commands.Handlers;
using SchoolManager.Entities;
using SchoolManager.IntegrationServices;
using SchoolManager.Repositories;
using Shouldly;
using Xunit;

namespace SchoolManager.Tests.Commands
{
    public class AddStudentTests
    {
        [Fact]
        public async Task ValidStudent_HandlerIsCalled_ReturnValidGuid() {
            // Arrange
            var addStudent = new Fixture().Create<AddStudent>();
            
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var erpIntegrationService = new Mock<IErpIntegrationService>();
            erpIntegrationService.Setup(e => e.SyncStudent(It.IsAny<ErpStudent>())).Returns(Task.FromResult(true));

            var addStudentHandler = new AddStudentHandler(studentRepositoryMock.Object, erpIntegrationService.Object);

            // Act
            var result = await addStudentHandler.Handle(addStudent, new CancellationToken());

            // Assert
            result.FullName.ShouldBe(addStudent.FullName);
            result.Document.ShouldBe(addStudent.Document);
            result.Class.ShouldBe(addStudent.Class);
            result.BirthDate.ShouldBe(addStudent.BirthDate);

            studentRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Student>()), Times.Once);
            erpIntegrationService.Verify(s => s.SyncStudent(It.IsAny<ErpStudent>()), Times.Once);
        }
    }
}