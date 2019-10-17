using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Student" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Student.svc or Student.svc.cs at the Solution Explorer and start debugging.
    public class Student : IStudent
    {
        #region Fields
        private StudentServiceApplication service = new StudentServiceApplication();
        #endregion

        public List<StudentDto> GetStudents()
        {
            return service.Get();
        }

        public StudentDto GetStudentByID(int id)
        {
            return service.GetById(id);
        }

        public string PostStudent(StudentDto studentDto)
        {
            if (!service.Save(studentDto))
                return "Student is not inserted";

            return "Student is inserted";
        }

        public string PutStudent(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }

        public string DeleteStudent(int id)
        {
            if (!service.Delete(id))
                return "Student is not deleted";

            return "Student is deleted";
        }

        public string Message()
        {
            return "The WCF service is up.";
        }
    }
}
