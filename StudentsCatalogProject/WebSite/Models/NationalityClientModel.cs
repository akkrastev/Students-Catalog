using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;


namespace WebSite.Models
{
    public class NationalityClientModel
    {
        public NationalityService.NationalityClient Service { get; set; }

        public NationalityClientModel()
        {
            this.Service = new NationalityService.NationalityClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "angel";
            this.Service.ClientCredentials.UserName.Password = "angel";
        }
    }
}