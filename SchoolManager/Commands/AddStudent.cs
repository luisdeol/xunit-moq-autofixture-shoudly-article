using System;
using MediatR;
using SchoolManager.Entities;

namespace SchoolManager.Commands
{
    public class AddStudent : IRequest<AddStudentViewModel>
    {
        public string FullName { get; set; }
        public string Document { get; set; }
        public string Class { get; set; }
        public DateTime BirthDate { get; set; }

        public Student ToEntity() 
            => new Student(FullName, Document, Class, BirthDate);
    }

    public class AddStudentViewModel {
        public AddStudentViewModel(Guid id, string fullName, string document, string @class, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            Document = document;
            Class = @class;
            BirthDate = birthDate;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Document { get; private set; }
        public string Class { get; private set; }
        public DateTime BirthDate { get; private set; }

        public static AddStudentViewModel FromEntity(Student student)
            => new AddStudentViewModel(student.Id, student.FullName, student.Document, student.Class, student.BirthDate);
    }
}