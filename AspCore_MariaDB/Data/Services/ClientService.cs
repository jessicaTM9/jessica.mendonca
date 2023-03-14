using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore_MariaDB.Data.Models;

public class ClientService
{
    public readonly ApplicationDbContext _dbContext;
    public User CurrentUser { get; private set; }

    public ClientService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Login(string username, string password)
    {
        var user = _dbContext.Users.SingleOrDefault(u => u.UserName == username && u.PasswordHash == password);
        if (user != null)
        {
            CurrentUser = user;
            return true;
        }
        return false;
    }
}

