
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using kme.Repositories;
using System.ComponentModel.DataAnnotations.Schema;


namespace kme.Models.Users
{


    public class User
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Gender { get; set; }
       // public string? Uimg { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ValidFrom { get; set; }
       // [Column(TypeName = "datetime2")]
        public DateTime? ValidTill { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Uimg { get; set; }

        // Add more properties as needed
    }


    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection string
        }

        }
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User? GetUserById(int userId)
        {
            var currentUser = context.Users.FirstOrDefault(u => u.Id == userId);
            
            return currentUser;
         }

        public User? GetUserByEmail(string email)
        {
            var currentUser = context.Users.FirstOrDefault(u => u.Email == email);

            return currentUser;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public void UpdateUser(User updatedUser)
        {
            User? existingUser = context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

            if (existingUser != null)
            {
                existingUser.UserName = updatedUser.UserName;
                existingUser.Email = updatedUser.Email;
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }

        private int GenerateUserId()
    {
            // Generate a unique user ID (you may want to use a more robust method)
            int usercount = context.Users.Count();
            return usercount;
    }

        public User WhereEmail(string email)
        {

            var data = table.FirstOrDefault(s => s.Email == email);
            return data;
        }
        public IEnumerable<User> CheckLogin(string email, string password)
        {
            var data = table.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
            return data;
        }
    }


}