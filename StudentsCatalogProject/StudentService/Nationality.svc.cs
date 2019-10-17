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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Nationality" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Nationality.svc or Nationality.svc.cs at the Solution Explorer and start debugging.
    public class Nationality : INationality
    {

        #region Fields
        private NationalityManagementService nationalityService = new NationalityManagementService();
        #endregion

        public string Testing()
        {
            return "WOOOHOOO service is up";
        }

        public string Message()
        {
            return "The WCF service is up.";
        }

        public List<NationalityDto> GetNationalities()
        {
            return nationalityService.Get();
        }

        public NationalityDto GetNationalityByID(int id)
        {
            return nationalityService.GetById(id);
        }

        public string PostNationality(NationalityDto nationalityDto)
        {
            if (!nationalityService.Save(nationalityDto))
                return "Nationality is not inserted";

            return "Nationality is inserted";
        }

        public string PutNationality(NationalityDto nationalityDto)
        {
            throw new NotImplementedException();
        }

        public string DeleteNationality(int id)
        {
            if (!nationalityService.Delete(id))
                return "Nationality is not deleted";

            return "Nationality is deleted";
        }
    }
}
