using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INationality" in both code and config file together.
    [ServiceContract]
    public interface INationality
    {
        [OperationContract]
        string Testing();

        [OperationContract]
        List<NationalityDto> GetNationalities();

        [OperationContract]
        NationalityDto GetNationalityByID(int id);

        [OperationContract]
        string PostNationality(NationalityDto nationalityDto);

        [OperationContract]
        string PutNationality(NationalityDto nationalityDto);

        [OperationContract]
        string DeleteNationality(int id);
    }
}
