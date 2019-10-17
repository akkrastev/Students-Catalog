using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using StudentService.Models;

namespace StudentService.App_Code.Authentication
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string username, string password)
        {

            AccountModel accountModel = new AccountModel();
            if(accountModel.login(username, password))
            {
                return;
            }
            throw new SecurityTokenException("Account's Invalid");
        }
    }
}