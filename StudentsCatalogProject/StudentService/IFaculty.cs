using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFaculty" in both code and config file together.
    [ServiceContract]
    public interface IFaculty
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<FacultyDto> GetFaculties();

        [OperationContract]
        FacultyDto GetFacultyByID(int id);

        [OperationContract]
        string PostFaculty(FacultyDto facultyDto);

        [OperationContract]
        string PutFaculty(FacultyDto facultyDto);

        [OperationContract]
        string DeleteFaculty(int id);

        
    }
}
