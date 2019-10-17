using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentService.Models
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>(); 

        public AccountModel()
        {
            listAccounts.Add(new Account { Username = "angel", Password = "angel" });
            listAccounts.Add(new Account { Username = "pesho", Password = "pesho" });
            listAccounts.Add(new Account { Username = "ivan", Password = "ivan" });
        }

        public bool login(string username, string password)
        {
            return listAccounts.Count(acc => acc.Username.Equals(username) && acc.Password.Equals(password)) > 0;
        }
    }
}