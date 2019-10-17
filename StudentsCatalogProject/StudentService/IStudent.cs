using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudent" in both code and config file together.
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<StudentDto> GetStudents();

        [OperationContract]
        StudentDto GetStudentByID(int id);

        [OperationContract]
        string PostStudent(StudentDto studentDto);

        [OperationContract]
        string PutStudent(StudentDto studentDto);

        [OperationContract]
        string DeleteStudent(int id);
    }
}
