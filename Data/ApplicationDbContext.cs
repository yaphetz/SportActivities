using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportActivities.Models;

namespace SportActivities.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Choice>().HasOne(x => x.FirstActivity)
            //    .WithMany(x => x.FirstChoices)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
            //builder.Entity<Choice>().HasOne(x => x.DefaultActivity)
            //    .WithMany(x => x.DefaultChoices)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Choice>().HasOne<Employee>(c => c.Employee)
                .WithMany(e => e.Choices)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Activity>()
                .HasMany<Choice>(c => c.FirstChoices)
                .WithOne(x => x.FirstActivity)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Activity>()
                .HasMany<Choice>(c => c.DefaultChoices)
                .WithOne(x => x.DefaultActivity)
                .OnDelete(DeleteBehavior.ClientSetNull);

            #region basic users and roles

            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ADMIN_ID = "a4280b6a-0653-4cbd-a0p6-f1701e926e73";
            const string BASIC_ID = "b4280b6a-0613-4ciod-a9e6-f1702f926e73";
            const string ROLE_BASIC_ID = "c9280b6a-0613-4cbd-a9e6-f1701e926e73";

            var hasher = new PasswordHasher<Employee>();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ADMIN_ID
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "basic",
                NormalizedName = "BASIC",
                Id = ROLE_BASIC_ID
            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = ADMIN_ID,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin@admin.com".ToUpper(),
                NormalizedEmail = "admin@admin.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "admin")
            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = BASIC_ID,
                FirstName = "Basic",
                LastName = "Basic",
                Email = "basic@basic.com",
                UserName = "basic@basic.com",
                EmailConfirmed = true,
                NormalizedUserName = "basic@basic.com".ToUpper(),
                NormalizedEmail = "basic@basic.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "basic")

            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ADMIN_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = BASIC_ID
            });

            #endregion

            #region some users

            const string FIRST_USER_ID = "b4280b6a-0613-4cbd-ae6-f1701e926e73";
            const string SECOND_USER_ID = "g4280b6a-0613-4awod-a9e6-f1702f926e73";
            const string THIRD_USER_ID = "5t280b6a-0613-4awod-a9e6-f1702f926e73";
            const string FOURTH_USER_ID = "acd80b6a-0613-4awod-a9e6-f1702f926e73";
            const string FIFTH_USER_ID = "bhd80b6a-0613-6awod-a9e6-f1702f926e73";
            const string SIXTH_USER_ID = "9cd80b6a-0613-8awod-a9e6-f1702f926e73";

            builder.Entity<Employee>().HasData(new Employee
            {
                Id = FIRST_USER_ID,
                FirstName = "Andrei",
                LastName = "Popescu",
                Email = "a.popescu@peoplepower.ro",
                UserName = "a.popescu@peoplepower.ro",
                EmailConfirmed = true,
                NormalizedUserName = "a.popescu@peoplepower.ro".ToUpper(),
                NormalizedEmail = "a.popescu@peoplepower.ro".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Andreipope$cu1")
            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = SECOND_USER_ID,
                FirstName = "Maria",
                LastName = "Gheorghe",
                Email = "m.gheorghe@peoplepower.ro",
                UserName = "m.gheorghe@peoplepower.ro",
                EmailConfirmed = true,
                NormalizedUserName = "m.gheorghe@peoplepower.ro".ToUpper(),
                NormalizedEmail = "m.gheorghe@peoplepower.ro".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "MariaGh#orgh#1")

            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = THIRD_USER_ID,
                FirstName = "Ionut",
                LastName = "Stanescu",
                Email = "i.stanescu@peoplepower.ro",
                UserName = "i.stanescu@peoplepower.ro",
                EmailConfirmed = true,
                NormalizedUserName = "i.stanescu@peoplepower.ro".ToUpper(),
                NormalizedEmail = "i.stanescu@peoplepower.ro".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Ionut$tane$cu2")

            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = FOURTH_USER_ID,
                FirstName = "Mircea",
                LastName = "Istrate",
                Email = "m.istrate@peoplepower.ro",
                UserName = "m.istrate@peoplepower.ro",
                EmailConfirmed = true,
                NormalizedUserName = "m.istrate@peoplepower.ro".ToUpper(),
                NormalizedEmail = "m.istrate@peoplepower.ro".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "M!rcea!$trate3")

            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = FIFTH_USER_ID,
                FirstName = "Marian",
                LastName = "Eremia",
                Email = "m.eremia@peoplepower.ro",
                UserName = "m.eremia@peoplepower.ro",
                EmailConfirmed = true,
                NormalizedUserName = "m.eremia@peoplepower.ro".ToUpper(),
                NormalizedEmail = "m.eremia@peoplepower.ro".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "M@ri@n3r3mi@")

            });
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = SIXTH_USER_ID,
                FirstName = "Ilinca",
                LastName = "Pop",
                Email = "i.pop@peoplepower.ro",
                UserName = "i.pop@peoplepower.ro",
                EmailConfirmed = true,
                NormalizedUserName = "i.pop@peoplepower.ro".ToUpper(),
                NormalizedEmail = "i.pop@peoplepower.ro".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "!L!nc@p0p")

            });
            
            
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = FIRST_USER_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = SECOND_USER_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = THIRD_USER_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = FIFTH_USER_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = FOURTH_USER_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = SIXTH_USER_ID
            });
            

            #endregion

            #region default activities
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 1,
                Name = "7Card",
                Status = true
            });
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 2,
                Name = "Belaqva",
                Status = true
            });
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 3,
                Name = "Paradisul Acvatic",
                Status = true
            });
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 4,
                Name = "Parc Aventura",
                Status = true
            });
            #endregion

            #region rejected activities
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 5,
                Name = "Inot",
                Status = false
            });
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 6,
                Name = "Bowling",
                Status = false
            });
            #endregion

            #region waiting for approval
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 7,
                Name = "Tenis",
                Status = null
            });
            builder.Entity<Activity>().HasData(new Activity
            {
                ActivityId = 8,
                Name = "Ping Pong",
                Status = null
            });

            //first not approved yet
            //default set
            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 1,
                DefaultActivityId = 2,
                FirstActivityId = 7,
                EmployeeId = FIRST_USER_ID,
                Date = new DateTime(2020, 10, 10)
            });

            //first rejected
            //default set
            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 2,
                DefaultActivityId = 1,
                FirstActivityId = 6,
                EmployeeId = SECOND_USER_ID,
                Date = new DateTime(2020, 10, 11)
            });

            //first rejected
            //default not set
            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 3,
                DefaultActivityId = null,
                FirstActivityId = 5,
                EmployeeId = THIRD_USER_ID,
                Date = new DateTime(2020, 10, 9)
            });

            //first not set
            //default set
            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 4,
                DefaultActivityId = 2,
                FirstActivityId = null,
                EmployeeId = FOURTH_USER_ID,
                Date = new DateTime(2020, 10, 9)
            });

            //first approved
            //default not set
            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 5,
                DefaultActivityId = null,
                FirstActivityId = 4,
                EmployeeId = FIFTH_USER_ID,
                Date = new DateTime(2020, 10, 10)
            });
            
            //first not approved yet
            //default not set
            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 6,
                DefaultActivityId = null,
                FirstActivityId = 7,
                EmployeeId = SIXTH_USER_ID,
                Date = new DateTime(2020, 10, 11)
            });
            #endregion
        }
    }
}
