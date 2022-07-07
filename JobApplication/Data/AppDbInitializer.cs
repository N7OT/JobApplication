using System.Collections.Generic;
using System.Linq;
using JobApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplication.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            Name = "First",
                            LastName = "One",
                            Phone = "0111111111",
                            Email = "1st@mail.com"
                        },
                        new User()
                        {
                            Name = "Second",
                            LastName = "Two",
                            Phone = "0222222222",
                            Email = "2nd@mail.com"
                        },
                        new User()
                        {
                            Name = "Third",
                            LastName = "Three",
                            Phone = "0333333333",
                            Email = "3rd@mail.com"
                        },
                        new User()
                        {
                            Name = "Fourth",
                            LastName = "Four",
                            Phone = "0111111111",
                            Email = "4th@mail.com"
                        }
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
