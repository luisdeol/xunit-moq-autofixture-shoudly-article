using System;
using SchoolManager.Entities;

namespace SchoolManager.IntegrationServices
{
    public class ErpStudent
    {
        public ErpStudent(string fullName, string schoolClass, string document, DateTime birthDate)
        {
            full_name = fullName;
            school_class = schoolClass;
            this.document = document;
            birth_date = birthDate;
        }

        public string full_name { get; private set; }
        public string school_class { get; private set; }
        public string document { get; private set; }
        public DateTime birth_date { get; private set; }

        public static ErpStudent FromEntity(Student student)
            => new ErpStudent(student.FullName, student.Class, student.Document, student.BirthDate);
    }
}