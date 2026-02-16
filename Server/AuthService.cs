using Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class AuthService
{
    public static string Login(string username, string password)
    {
        using (var db = new TaskManagerEntities2())
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
    
    public static async Task<string> LoginAsync(string username, string password)
    {
        using (var db = new TaskManagerEntities2())
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
    public static async Task<string> RegisterAsync(string username, string password, string email)
    {
        using (var db = new TaskManagerEntities2())
        {
            var user_exist = await db.Users.AnyAsync(u => u.username == username);

            if (user_exist)
            {
                return "USER_EXISTS";
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            Users user = new Users()
            {
                username = username,
                hash_password = passwordHash,
                email = email,
                lvl_security = 0
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            return "SUCCESS";
        }
    }
}

