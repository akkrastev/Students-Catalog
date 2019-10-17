using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;

namespace WebSite.Models
{
    public class FacultyClientModel
    {
        public FacultyService.FacultyClient Service { get; set; }

        public FacultyClientModel()
        {
            this.Service = new FacultyService.FacultyClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "angel";
            this.Service.ClientCredentials.UserName.Password = "angel";
        }
    }
}