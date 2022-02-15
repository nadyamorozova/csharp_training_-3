using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    class AccountData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private string name;
        private string password;
        public AccountData()
        {
            this.Name = name;
            this.Password = password;
        }

    }
}

