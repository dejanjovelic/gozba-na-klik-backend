using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            using var context = serviceProvider.GetRequiredService<AppDbContext>();




            var administrators = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "a1f2c3d4-e5f6-7890-ab12-cd34ef56gh78",
                    Name = "Ashley",
                    Surname = "Diaz",
                    Email = "walkerlaura@example.net",
                    UserName = "admin1",
                    PhoneNumber = "+381601112223",
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "b2e3f4g5-h6i7-8901-bc23-de45fg67hi89",
                    Name = "Michelle",
                    Surname = "Nguyen",
                    Email = "davidmullins@example.org",
                    UserName = "admin2",
                    PhoneNumber = "+381611234567",
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "c3f4g5h6-i7j8-9012-cd34-ef56gh78ij90",
                    Name = "Robert",
                    Surname = "Barton",
                    Email = "andersonnicholas@example.com",
                    UserName = "admin3",
                    PhoneNumber = "+381641234890",
                    EmailConfirmed = true
                }
            };

            foreach (var admin in administrators)
            {
                var existingUser = await userManager.FindByNameAsync(admin.UserName);

                if (existingUser == null)
                {
                    var createResult = await userManager.CreateAsync(admin, "Admin@123");
                    if (createResult.Succeeded)
                    {
                        existingUser = admin;
                    }
                    else
                    {
                        Console.WriteLine($"Error while creating admin {admin.UserName}: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                        continue;
                    }
                }

                if (!await userManager.IsInRoleAsync(existingUser, "Administrator"))
                {
                    await userManager.AddToRoleAsync(existingUser, "Administrator");
                }

                if (!await context.Administrators.AnyAsync(a => a.Id == existingUser.Id))
                {
                    context.Administrators.Add(new Administrator
                    {
                        Id = existingUser.Id
                    });
                }


            }

            var customers = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
                    Name = "Ashley",
                    Surname = "Green",
                    Email = "caseymaria@example.com",
                    UserName = "customer4",
                    PhoneNumber = "+381621112223",
                    DateOfBirth = new DateTime(1995, 5, 10, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                    Name = "Emily",
                    Surname = "Austin",
                    Email = "reynoldscourtney@example.net",
                    UserName = "customer5",
                    PhoneNumber = "+381631234567",
                    DateOfBirth = new DateTime(2000, 1, 25, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03",
                    Name = "Wendy",
                    Surname = "Vargas",
                    Email = "michael99@example.org",
                    UserName = "customer6",
                    PhoneNumber = "+381601234321",
                    DateOfBirth = new DateTime(1988, 12, 3, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04",
                    Name = "Kimberly",
                    Surname = "Brown",
                    Email = "robertschristopher@example.net",
                    UserName = "customer7",
                    PhoneNumber = "+381641112233",
                    DateOfBirth = new DateTime(1991, 7, 18, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05",
                    Name = "David",
                    Surname = "Sims",
                    Email = "nelsonrebecca@example.com",
                    UserName = "customer8",
                    PhoneNumber = "+381611231231",
                    DateOfBirth = new DateTime(1975, 4, 2, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06",
                    Name = "Christine",
                    Surname = "Maldonado",
                    Email = "matthew11@example.org",
                    UserName = "customer9",
                    PhoneNumber = "+381621234890",
                    DateOfBirth = new DateTime(2003, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07",
                    Name = "William",
                    Surname = "Huff",
                    Email = "heathermartinez@example.org",
                    UserName = "customer10",
                    PhoneNumber = "+381601113355",
                    DateOfBirth = new DateTime(1965, 9, 29, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08",
                    Name = "Ryan",
                    Surname = "Bennett",
                    Email = "linda83@example.com",
                    UserName = "customer11",
                    PhoneNumber = "+381631234444",
                    DateOfBirth = new DateTime(1999, 3, 7, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09",
                    Name = "Sean",
                    Surname = "Butler",
                    Email = "stevensholly@example.org",
                    UserName = "customer12",
                    PhoneNumber = "+381641112567",
                    DateOfBirth = new DateTime(1982, 6, 14, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10",
                    Name = "Timothy",
                    Surname = "Horton",
                    Email = "nelsonpaul@example.net",
                    UserName = "customer13",
                    PhoneNumber = "+381611114455",
                    DateOfBirth = new DateTime(1990, 2, 28, 0, 0, 0, DateTimeKind.Utc),
                    EmailConfirmed = true
                }
            };

            foreach (var customer in customers)
            {
                var existingUser = await userManager.FindByNameAsync(customer.UserName);

                if (existingUser == null)
                {
                    var createResult = await userManager.CreateAsync(customer, "Cust@123");
                    if (createResult.Succeeded)
                    {
                        existingUser = customer;
                    }
                    else
                    {
                        Console.WriteLine($"Error while creating customer {customer.UserName}: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                        continue;
                    }
                }

                if (!await userManager.IsInRoleAsync(existingUser, "Customer"))
                {
                    await userManager.AddToRoleAsync(existingUser, "Customer");
                }

                if (!await context.Customers.AnyAsync(cu => cu.Id == existingUser.Id))
                {
                    context.Customers.Add(new Customer
                    {
                        Id = existingUser.Id
                    });
                }
            }



            var couriers = new List<ApplicationUser>
            {
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
                    Name = "Jessica",
                    Surname = "Nguyen",
                    Email = "jameswells@example.net",
                    UserName = "courier14",
                    PhoneNumber = "+381621234567",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
                    Name = "Samantha",
                    Surname = "Jackson",
                    Email = "turneremily@example.net",
                    UserName = "courier15",
                    PhoneNumber = "+381631118889",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16",
                    Name = "Nicholas",
                    Surname = "Mcdaniel",
                    Email = "stephaniedavis@example.com",
                    UserName = "courier16",
                    ProfileImageUrl = "",
                    PhoneNumber = "+381601231111",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh17",
                    Name = "Edward",
                    Surname = "Morgan",
                    Email = "laura66@example.net",
                    UserName = "courier17",
                    PhoneNumber = "+381641112001",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh18",
                    Name = "Tina",
                    Surname = "Collins",
                    Email = "aliciamurray@example.org",
                    UserName = "courier18",
                    PhoneNumber = "+381611234678",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh19",
                    Name = "Kimberly",
                    Surname = "Schroeder",
                    Email = "michael37@example.com",
                    UserName = "courier19",
                    PhoneNumber = "+381621112999",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20",
                    Name = "Paul",
                    Surname = "Owen",
                    Email = "sarahhill@example.com",
                    UserName = "courier20",
                    PhoneNumber = "+381631234001",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21",
                    Name = "Patricia",
                    Surname = "Evans",
                    Email = "keith54@example.com",
                    UserName = "courier21",
                    PhoneNumber = "+381601118880",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22",
                    Name = "Kimberly",
                    Surname = "Brock",
                    Email = "jessicaduncan@example.org",
                    UserName = "courier22",
                    PhoneNumber = "+381641113456",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23",
                    Name = "David",
                    Surname = "Chavez",
                    Email = "hannah67@example.org",
                    UserName = "courier23",
                    PhoneNumber = "+381611231987",
                    EmailConfirmed = true
                }
            };

            foreach (var courier in couriers)
            {
                var existing = await userManager.FindByNameAsync(courier.UserName);
                if (existing == null)
                {
                    var createResult = await userManager.CreateAsync(courier, "Courier@123");
                    if (createResult.Succeeded)
                    {
                        existing = courier;
                    }
                    else
                    {
                        Console.WriteLine($"Error while creating courier {courier.UserName}: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                        continue;
                    }
                }

                if (!await userManager.IsInRoleAsync(existing, "Courier"))
                {
                    await userManager.AddToRoleAsync(existing, "Courier");
                }

                if (!await context.Couriers.AnyAsync(c => c.Id == existing.Id))
                {
                    context.Couriers.Add(new Courier
                    {
                        Id = existing.Id
                    });
                }
            }

            var restaurantOwners = new List<ApplicationUser>
            {
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24",
                    Name = "Victor",
                    Surname = "Diaz",
                    Email = "victor.diaz@example.com",
                    UserName = "owner24",
                    PhoneNumber = "+381621111234",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh25",
                    Name = "Laura",
                    Surname = "Smith",
                    Email = "laura.smith@example.com",
                    UserName = "owner25",
                    PhoneNumber = "+381631234222",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh26",
                    Name = "James",
                    Surname = "Johnson",
                    Email = "james.johnson@example.com",
                    UserName = "owner26",
                    PhoneNumber = "+381601118899",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh27",
                    Name = "Olivia",
                    Surname = "Brown",
                    Email = "olivia.brown@example.com",
                    UserName = "owner27",
                    PhoneNumber = "+381641234654",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28",
                    Name = "Ethan",
                    Surname = "Williams",
                    Email = "ethan.williams@example.com",
                    UserName = "owner28",
                    PhoneNumber = "+381611112345",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh29",
                    Name = "Sophia",
                    Surname = "Jones",
                    Email = "sophia.jones@example.com",
                    UserName = "owner29",
                    PhoneNumber = "+381621113333",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh30",
                    Name = "Mason",
                    Surname = "Garcia",
                    Email = "mason.garcia@example.com",
                    UserName = "owner30",
                    PhoneNumber = "+381631112001",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh31",
                    Name = "Isabella",
                    Surname = "Martinez",
                    Email = "isabella.martinez@example.com",
                    UserName = "owner31",
                    PhoneNumber = "+381601118123",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh32",
                    Name = "Logan",
                    Surname = "Rodriguez",
                    Email = "logan.rodriguez@example.com",
                    UserName = "owner32",
                    PhoneNumber = "+381641231231",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh33",
                    Name = "Ava",
                    Surname = "Lee",
                    Email = "ava.lee@example.com",
                    UserName = "owner33",
                    PhoneNumber = "+381611234432",
                    EmailConfirmed = true
                }
            };

            foreach (var owner in restaurantOwners)
            {
                var existing = await userManager.FindByNameAsync(owner.UserName);
                if (existing == null)
                {
                    var createResult = await userManager.CreateAsync(owner, "Owner@123");
                    if (createResult.Succeeded)
                    {
                        existing = owner;
                    }
                    else
                    {
                        Console.WriteLine($"Error while creating restaurant owner {owner.UserName}: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                        continue;
                    }
                }

                if (!await userManager.IsInRoleAsync(existing, "RestaurantOwner"))
                {
                    await userManager.AddToRoleAsync(existing, "RestaurantOwner");
                }

                if (!await context.RestaurantOwners.AnyAsync(ro => ro.Id == existing.Id))
                {
                    context.RestaurantOwners.Add(new RestaurantOwner
                    {
                        Id = existing.Id
                    });
                }
            }


            var employees = new List<ApplicationUser>
            {
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh34",
                    Name = "Noah",
                    Surname = "Walker",
                    Email = "noah.walker@example.com",
                    UserName = "employee34",
                    PhoneNumber = "+381621112777",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh35",
                    Name = "Mia",
                    Surname = "Hall",
                    Email = "mia.hall@example.com",
                    UserName = "employee35",
                    PhoneNumber = "+381631234123",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh36",
                    Name = "Liam",
                    Surname = "Allen",
                    Email = "liam.allen@example.com",
                    UserName = "employee36",
                    PhoneNumber = "+381601119900",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh37",
                    Name = "Charlotte",
                    Surname = "Young",
                    Email = "charlotte.young@example.com",
                    UserName = "employee37",
                    PhoneNumber = "+381641118765",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh38",
                    Name = "Jacob",
                    Surname = "Hernandez",
                    Email = "jacob.hernandez@example.com",
                    UserName = "employee38",
                    PhoneNumber = "+381611112888",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh39",
                    Name = "Amelia",
                    Surname = "King",
                    Email = "amelia.king@example.com",
                    UserName = "employee39",
                    PhoneNumber = "+381621112555",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh40",
                    Name = "Evelyn",
                    Surname = "Wright",
                    Email = "evelyn.wright@example.com",
                    UserName = "employee40",
                    PhoneNumber = "+381631119111",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh41",
                    Name = "Alexander",
                    Surname = "Lopez",
                    Email = "alexander.lopez@example.com",
                    UserName = "employee41",
                    PhoneNumber = "+381601113789",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh42",
                    Name = "Ella",
                    Surname = "Hill",
                    Email = "ella.hill@example.com",
                    UserName = "employee42",
                    PhoneNumber = "+381641112456",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh43",
                    Name = "Michael",
                    Surname = "Scott",
                    Email = "michael.scott@example.com",
                    UserName = "employee43",
                    PhoneNumber = "+381611231111",
                    EmailConfirmed = true
                }
            };

            foreach (var employee in employees)
            {
                var existing = await userManager.FindByNameAsync(employee.UserName);
                if (existing == null)
                {
                    var createResult = await userManager.CreateAsync(employee, "Employee@123");
                    if (createResult.Succeeded)
                    {
                        existing = employee;
                    }
                    else
                    {
                        Console.WriteLine($"Error while creating employee {employee.UserName}: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                        continue;
                    }

                }

                if (!await userManager.IsInRoleAsync(existing, "Employee"))
                {
                    await userManager.AddToRoleAsync(existing, "Employee");
                }

                if (!await context.Employees.AnyAsync(e => e.Id == existing.Id))
                {
                    context.Employees.Add(new Employee
                    {
                        Id = existing.Id
                    });
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
