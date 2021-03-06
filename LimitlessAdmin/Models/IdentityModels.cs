﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LimitlessAdmin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Audit_Log> Audit_Logs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<ObjOfTop> ObjOfTops { get; set; }
        public DbSet<SubObjective> SubObjectives { get; set; }
        public DbSet<SubObjOfObj> SubObjOfObjs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QueOfSubObj> QueOfSubObjs { get; set; }
        public DbSet<Answer> Answers { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}