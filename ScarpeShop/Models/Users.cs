using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScarpeShop.Models
{
    public class Users
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Psw { get; set; }
        public string Role { get; set; }
        public Users() { }
        public Users(int idUser, string username, string psw, string role)
        {
            IdUser = idUser;
            Username = username;
            Psw = psw;
            Role = role;
        }
    }
}