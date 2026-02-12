using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
public static class AuthService
{
    public static string Login(string username, string password) 
    {
        using (var db = new TaskManagerEntities1())
        {
            var user = db.Users.FirstOrDefault(u => u.username == username);
            if (user == null) 
            {
                return "NOT_FOUND";
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.hash_password);

            if (!isValid) 
            {
                return "WRONG_PASSWORD";
            }
            return "SUCCESS";
        }
    }
}

