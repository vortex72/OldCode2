using eClub.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace eClub.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationRole> MyRoles { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("ModelBuilder is NULL");
            }

            base.OnModelCreating(modelBuilder);

            //Defining the keys and relations
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<SECUserModel>().ToTable("SECUser");
            modelBuilder.Entity<LeadsModel>().ToTable("mReferred");
            modelBuilder.Entity<ApplicationRole>().HasKey<string>(r => r.Id).ToTable("AspNetRoles");
            //modelBuilder.Entity<RoleScreenViewModel>().HasKey(r => new { RoleId = r.SECRole_ID, ScreenID = r.SECScreen_ID }).ToTable("SECRoleScreen");
            modelBuilder.Entity<AppTables>().HasKey<int>(r => r.MasterTable_ID).ToTable("MasterTable");
            modelBuilder.Entity<ApplicationUser>().HasMany<ApplicationUserRole>((ApplicationUser u) => u.UserRoles);
            modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");
            //modelBuilder.Entity<AppRoleScreens>().HasKey(r => new { RoleId = r.RoleId, ScreenId = r.ScreenId }).ToTable("RoleScreen");
            modelBuilder.Entity<AppModules>().HasKey<int>(r => r.dSECModule_ID).ToTable("dSECModule");
        }

        public bool Seed(ApplicationDbContext context)
        {
            bool success = false;
            /*#if DEBUG
                        ApplicationRoleManager _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

                        success = this.CreateRole(_roleManager, "Admin", "Global Access");
                        if (!success == true) return success;

                        success = this.CreateRole(_roleManager, "CanEdit", "Edit existing records");
                        if (!success == true) return success;

                        success = this.CreateRole(_roleManager, "User", "Restricted to business domain activity");
                        if (!success) return success;

                        // Create my debug (testing) objects here

            #endif*/
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationUser user = new ApplicationUser();
            PasswordHasher passwordHasher = new PasswordHasher();

            user.UserName = "youremail@testemail.com";
            user.Email = "youremail@testemail.com";

            IdentityResult result = userManager.Create(user, "Pass@123");
            success = true;
            /*#if DEBUG   
                        success = this.AddUserToRole(userManager, user.Id, "Admin");
                        if (!success) return success;

                        success = this.AddUserToRole(userManager, user.Id, "CanEdit");
                        if (!success) return success;

                        success = this.AddUserToRole(userManager, user.Id, "User");
                        if (!success) return success;

            #endif*/
            return success;

        }

        public bool RoleExists(ApplicationRoleManager roleManager, string name)
        {
            return roleManager.RoleExists(name);
        }

        public bool CreateRole(ApplicationRoleManager _roleManager, string name, string description = "")
        {
            var idResult = _roleManager.Create<ApplicationRole, string>(new ApplicationRole(name, description));
            return idResult.Succeeded;
        }

        public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(ApplicationUserManager userManager, string userId)
        {
            var user = userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.UserRoles);
            foreach (ApplicationUserRole role in currentRoles)
            {
                userManager.RemoveFromRole(userId, role.Role.Name);
            }
        }


        public void RemoveFromRole(ApplicationUserManager userManager, string userId, string roleName)
        {
            userManager.RemoveFromRole(userId, roleName);
        }

        public void DeleteRole(ApplicationDbContext context, ApplicationUserManager userManager, string roleId)
        {
            var roleUsers = context.Users.Where(u => u.UserRoles.Any(r => r.RoleId == roleId));
            var role = context.MyRoles.Find(roleId);

            foreach (var user in roleUsers)
            {
                this.RemoveFromRole(userManager, user.Id, role.Name);
            }
            context.MyRoles.Remove(role);
            context.SaveChanges();
        }

        public System.Data.Entity.DbSet<eClub.Models.SECUserModel> SECUsers { get; set; }
        public System.Data.Entity.DbSet<eClub.Models.AppModules> AppModules { get; set; }
        public System.Data.Entity.DbSet<eClub.Models.AppTables> AppTables { get; set; }
        public System.Data.Entity.DbSet<eClub.Models.mProduct> mProducts { get; set; }
        public System.Data.Entity.DbSet<eClub.Models.DescriptionTables> DescriptionTables { get; set; }
        public System.Data.Entity.DbSet<eClub.Models.RoleModuleViewModel> SECRoleModule { get; set; }
        public System.Data.Entity.DbSet<eClub.Models.mSubProduct> mSubProducts { get; set; }

        //public System.Data.Entity.DbSet<RBAC2.Models.ApplicationUser> ApplicationUsers { get; set; }

        /// <summary>
        /// Context Initializer
        /// </summary>
        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        public System.Data.Entity.DbSet<eClub.Models.LeadsModel> LeadsModels { get; set; }

        public System.Data.Entity.DbSet<eClub.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<eClub.Models.CardType> CardType { get; set; }

        public System.Data.Entity.DbSet<eClub.Models.IssuerBank> IssuerBank { get; set; }

        public System.Data.Entity.DbSet<eClub.Models.Benefit> Benefits { get; set; }
    }

}