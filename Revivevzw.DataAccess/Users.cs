using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Language { get; set; }
        public string Admin { get; set; }
        public string Tel { get; set; }
        public string Gsm { get; set; }
        public string Deleted { get; set; }
        public DateTime Dcreated { get; set; }
        public DateTime Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
