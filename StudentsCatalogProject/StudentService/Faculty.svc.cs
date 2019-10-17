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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Faculty" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Faculty.svc or Faculty.svc.cs at the Solution Explorer and start debugging.
    public class Faculty : IFaculty
    {

        #region
        private FacultyManagementService facultyServise = new FacultyManagementService();
        #endregion

        public string Message()
        {
            return "The WCF service is up.";
        }

        public List<FacultyDto> GetFaculties()
        {
            return facultyServise.Get();
        }

        public FacultyDto GetFacultyByID(int id)
        {
            return facultyServise.GetById(id);
        }

        public string PostFaculty(FacultyDto facultyDto)
        {
            if (!facultyServise.Save(facultyDto))
            {
                return "Faculty is inserted";
            }

            return "Faculty is inserted";
        }

        public string PutFaculty(FacultyDto facultyDto)
        {
            throw new NotImplementedException();
        }

        public string DeleteFaculty(int id)
        {
            if (!facultyServise.Delete(id))
            {
                return "Faculty is not deleted";
            }

            return "Faculty is deleted";
        }

       
    }
}
