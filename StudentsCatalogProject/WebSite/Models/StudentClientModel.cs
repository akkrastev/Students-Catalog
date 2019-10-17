using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;

namespace WebSite.Models
{
    public class StudentClientModel
    {
        public StudentService.StudentClient Service { get; set; }

        public StudentClientModel()
        {
            this.Service = new StudentService.StudentClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "angel";
            this.Service.ClientCredentials.UserName.Password = "angel";
        }
    }
}