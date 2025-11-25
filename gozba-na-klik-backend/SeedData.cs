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
                    ProfileImageUrl = "https://example.com/admin1.png",
                    PhoneNumber = "+381601112223"
                },
                new ApplicationUser
                {
                    Id = "b2e3f4g5-h6i7-8901-bc23-de45fg67hi89",
                    Name = "Michelle",
                    Surname = "Nguyen",
                    Email = "davidmullins@example.org",
                    UserName = "admin2",
                    ProfileImageUrl = "https://example.com/admin2.png",
                    PhoneNumber = "+381611234567"
                },
                new ApplicationUser
                {
                    Id = "c3f4g5h6-i7j8-9012-cd34-ef56gh78ij90",
                    Name = "Robert",
                    Surname = "Barton",
                    Email = "andersonnicholas@example.com",
                    UserName = "admin3",
                    ProfileImageUrl = "https://example.com/admin3.png",
                    PhoneNumber = "+381641234890"
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
                    ProfileImageUrl = "https://example.com/customer4.png",
                    PhoneNumber = "+381621112223",
                    DateOfBirth = new DateTime(1995, 5, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                    Name = "Emily",
                    Surname = "Austin",
                    Email = "reynoldscourtney@example.net",
                    UserName = "customer5",
                    ProfileImageUrl = "https://example.com/customer5.png",
                    PhoneNumber = "+381631234567",
                    DateOfBirth = new DateTime(2000, 1, 25, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03",
                    Name = "Wendy",
                    Surname = "Vargas",
                    Email = "michael99@example.org",
                    UserName = "customer6",
                    ProfileImageUrl = "https://example.com/customer6.png",
                    PhoneNumber = "+381601234321",
                    DateOfBirth = new DateTime(1988, 12, 3, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04",
                    Name = "Kimberly",
                    Surname = "Brown",
                    Email = "robertschristopher@example.net",
                    UserName = "customer7",
                    ProfileImageUrl = "https://example.com/customer7.png",
                    PhoneNumber = "+381641112233",
                    DateOfBirth = new DateTime(1991, 7, 18, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05",
                    Name = "David",
                    Surname = "Sims",
                    Email = "nelsonrebecca@example.com",
                    UserName = "customer8",
                    ProfileImageUrl = "https://example.com/customer8.png",
                    PhoneNumber = "+381611231231",
                    DateOfBirth = new DateTime(1975, 4, 2, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06",
                    Name = "Christine",
                    Surname = "Maldonado",
                    Email = "matthew11@example.org",
                    UserName = "customer9",
                    ProfileImageUrl = "https://example.com/customer9.png",
                    PhoneNumber = "+381621234890",
                    DateOfBirth = new DateTime(2003, 11, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07",
                    Name = "William",
                    Surname = "Huff",
                    Email = "heathermartinez@example.org",
                    UserName = "customer10",
                    ProfileImageUrl = "https://example.com/customer10.png",
                    PhoneNumber = "+381601113355",
                    DateOfBirth = new DateTime(1965, 9, 29, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08",
                    Name = "Ryan",
                    Surname = "Bennett",
                    Email = "linda83@example.com",
                    UserName = "customer11",
                    ProfileImageUrl = "https://example.com/customer11.png",
                    PhoneNumber = "+381631234444",
                    DateOfBirth = new DateTime(1999, 3, 7, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09",
                    Name = "Sean",
                    Surname = "Butler",
                    Email = "stevensholly@example.org",
                    UserName = "customer12",
                    ProfileImageUrl = "https://example.com/customer12.png",
                    PhoneNumber = "+381641112567",
                    DateOfBirth = new DateTime(1982, 6, 14, 0, 0, 0, DateTimeKind.Utc)
                },
                new ApplicationUser
                {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10",
                    Name = "Timothy",
                    Surname = "Horton",
                    Email = "nelsonpaul@example.net",
                    UserName = "customer13",
                    ProfileImageUrl = "https://example.com/customer13.png",
                    PhoneNumber = "+381611114455",
                    DateOfBirth = new DateTime(1990, 2, 28, 0, 0, 0, DateTimeKind.Utc)
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
                    ProfileImageUrl = "https://example.com/courier14.png",
                    PhoneNumber = "+381621234567"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
                    Name = "Samantha",
                    Surname = "Jackson",
                    Email = "turneremily@example.net",
                    UserName = "courier15",
                    ProfileImageUrl = "https://example.com/courier15.png",
                    PhoneNumber = "+381631118889"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16",
                    Name = "Nicholas",
                    Surname = "Mcdaniel",
                    Email = "stephaniedavis@example.com",
                    UserName = "courier16",
                    ProfileImageUrl = "https://example.com/courier16.png",
                    PhoneNumber = "+381601231111"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh17",
                    Name = "Edward",
                    Surname = "Morgan",
                    Email = "laura66@example.net",
                    UserName = "courier17",
                    ProfileImageUrl = "https://example.com/courier17.png",
                    PhoneNumber = "+381641112001"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh18",
                    Name = "Tina",
                    Surname = "Collins",
                    Email = "aliciamurray@example.org",
                    UserName = "courier18",
                    ProfileImageUrl = "https://example.com/courier18.png",
                    PhoneNumber = "+381611234678"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh19",
                    Name = "Kimberly",
                    Surname = "Schroeder",
                    Email = "michael37@example.com",
                    UserName = "courier19",
                    ProfileImageUrl = "https://example.com/courier19.png",
                    PhoneNumber = "+381621112999"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20",
                    Name = "Paul",
                    Surname = "Owen",
                    Email = "sarahhill@example.com",
                    UserName = "courier20",
                    ProfileImageUrl = "https://example.com/courier20.png",
                    PhoneNumber = "+381631234001"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21",
                    Name = "Patricia",
                    Surname = "Evans",
                    Email = "keith54@example.com",
                    UserName = "courier21",
                    ProfileImageUrl = "https://example.com/courier21.png",
                    PhoneNumber = "+381601118880"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22",
                    Name = "Kimberly",
                    Surname = "Brock",
                    Email = "jessicaduncan@example.org",
                    UserName = "courier22",
                    ProfileImageUrl = "https://example.com/courier22.png",
                    PhoneNumber = "+381641113456"
                },
                new ApplicationUser {
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23",
                    Name = "David",
                    Surname = "Chavez",
                    Email = "hannah67@example.org",
                    UserName = "courier23",
                    ProfileImageUrl = "https://example.com/courier23.png",
                    PhoneNumber = "+381611231987"
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
                    ProfileImageUrl = "https://example.com/owner24.png",
                    PhoneNumber = "+381621111234"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh25",
                    Name = "Laura",
                    Surname = "Smith",
                    Email = "laura.smith@example.com",
                    UserName = "owner25",
                    ProfileImageUrl = "https://example.com/owner25.png",
                    PhoneNumber = "+381631234222"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh26",
                    Name = "James",
                    Surname = "Johnson",
                    Email = "james.johnson@example.com",
                    UserName = "owner26",
                    ProfileImageUrl = "https://example.com/owner26.png",
                    PhoneNumber = "+381601118899"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh27",
                    Name = "Olivia",
                    Surname = "Brown",
                    Email = "olivia.brown@example.com",
                    UserName = "owner27",
                    ProfileImageUrl = "https://example.com/owner27.png",
                    PhoneNumber = "+381641234654"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28",
                    Name = "Ethan",
                    Surname = "Williams",
                    Email = "ethan.williams@example.com",
                    UserName = "owner28",
                    ProfileImageUrl = "https://example.com/owner28.png",
                    PhoneNumber = "+381611112345"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh29",
                    Name = "Sophia",
                    Surname = "Jones",
                    Email = "sophia.jones@example.com",
                    UserName = "owner29",
                    ProfileImageUrl = "https://example.com/owner29.png",
                    PhoneNumber = "+381621113333"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh30",
                    Name = "Mason",
                    Surname = "Garcia",
                    Email = "mason.garcia@example.com",
                    UserName = "owner30",
                    ProfileImageUrl = "https://example.com/owner30.png",
                    PhoneNumber = "+381631112001"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh31",
                    Name = "Isabella",
                    Surname = "Martinez",
                    Email = "isabella.martinez@example.com",
                    UserName = "owner31",
                    ProfileImageUrl = "https://example.com/owner31.png",
                    PhoneNumber = "+381601118123"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh32",
                    Name = "Logan",
                    Surname = "Rodriguez",
                    Email = "logan.rodriguez@example.com",
                    UserName = "owner32",
                    ProfileImageUrl = "https://example.com/owner32.png",
                    PhoneNumber = "+381641231231"
                },
                new ApplicationUser {
                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh33",
                    Name = "Ava",
                    Surname = "Lee",
                    Email = "ava.lee@example.com",
                    UserName = "owner33",
                    ProfileImageUrl = "https://example.com/owner33.png",
                    PhoneNumber = "+381611234432"
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
                    ProfileImageUrl = "https://example.com/employee34.png",
                    PhoneNumber = "+381621112777"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh35",
                    Name = "Mia",
                    Surname = "Hall",
                    Email = "mia.hall@example.com",
                    UserName = "employee35",
                    ProfileImageUrl = "https://example.com/employee35.png",
                    PhoneNumber = "+381631234123"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh36",
                    Name = "Liam",
                    Surname = "Allen",
                    Email = "liam.allen@example.com",
                    UserName = "employee36",
                    ProfileImageUrl = "https://example.com/employee36.png",
                    PhoneNumber = "+381601119900"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh37",
                    Name = "Charlotte",
                    Surname = "Young",
                    Email = "charlotte.young@example.com",
                    UserName = "employee37",
                    ProfileImageUrl = "https://example.com/employee37.png",
                    PhoneNumber = "+381641118765"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh38",
                    Name = "Jacob",
                    Surname = "Hernandez",
                    Email = "jacob.hernandez@example.com",
                    UserName = "employee38",
                    ProfileImageUrl = "https://example.com/employee38.png",
                    PhoneNumber = "+381611112888"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh39",
                    Name = "Amelia",
                    Surname = "King",
                    Email = "amelia.king@example.com",
                    UserName = "employee39",
                    ProfileImageUrl = "https://example.com/employee39.png",
                    PhoneNumber = "+381621112555"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh40",
                    Name = "Evelyn",
                    Surname = "Wright",
                    Email = "evelyn.wright@example.com",
                    UserName = "employee40",
                    ProfileImageUrl = "https://example.com/employee40.png",
                    PhoneNumber = "+381631119111"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh41",
                    Name = "Alexander",
                    Surname = "Lopez",
                    Email = "alexander.lopez@example.com",
                    UserName = "employee41",
                    ProfileImageUrl = "https://example.com/employee41.png",
                    PhoneNumber = "+381601113789"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh42",
                    Name = "Ella",
                    Surname = "Hill",
                    Email = "ella.hill@example.com",
                    UserName = "employee42",
                    ProfileImageUrl = "https://example.com/employee42.png",
                    PhoneNumber = "+381641112456"
                },
                new ApplicationUser {
                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh43",
                    Name = "Michael",
                    Surname = "Scott",
                    Email = "michael.scott@example.com",
                    UserName = "employee43",
                    ProfileImageUrl = "https://example.com/employee43.png",
                    PhoneNumber = "+381611231111"
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
