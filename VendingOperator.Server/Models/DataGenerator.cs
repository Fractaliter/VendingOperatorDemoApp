using VendingOperator.Shared.Models;
using Bogus;
using System.Data;

namespace VendingOperator.Server.Models
{
    public class DataGenerator
    {
        public static void Initialize(AppDbContext appDbContext)
        {
            Randomizer.Seed = new Random(32321);
            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();
            if (!(appDbContext.People.Any()))
                {
                    //Create test addresses
                    var testAddresses = new Faker<Address>()
                        .RuleFor(a => a.Street, f => f.Address.StreetAddress())
                        .RuleFor(a => a.City, f => f.Address.City())
                        .RuleFor(a => a.State, f => f.Address.State())
                        .RuleFor(a => a.ZipCode, f => f.Address.ZipCode());

                    // Create new people
                    var testPeople = new Faker<VendingOperator.Shared.Models.Person>()
                        .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                        .RuleFor(p => p.LastName, f => f.Name.LastName())
                        .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                        .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
                        .RuleFor(p => p.Addresses, f => testAddresses.Generate(2).ToList());
                        
                    var people = testPeople.Generate(25);

                    foreach (VendingOperator.Shared.Models.Person p in people)
                    {
                        appDbContext.People.Add(p);
                    }
                    appDbContext.SaveChanges();
                }

            if (!(appDbContext.Uploads.Any()))
            {
                string jsonRecord = @"[{""FirstName"": ""Tim"",""LastName"": ""Bucktooth"",""Gender"": 1,""PhoneNumber"": ""717-211-3211"",
                    ""Addresses"": [{""Street"": ""415 McKee Place"",""City"": ""Pittsburgh"",""State"": ""Pennsylvania"",""ZipCode"": ""15140""
                    },{ ""Street"": ""315 Gunpowder Road"",""City"": ""Mechanicsburg"",""State"": ""Pennsylvania"",""ZipCode"": ""17101""  }]}]";
                var testUploads = new Faker<Upload>()
                    .RuleFor(u => u.FileName, u => u.Lorem.Word()+".json")
                    .RuleFor(u => u.UploadTimestamp, u => u.Date.Past(1, DateTime.Now))
                    .RuleFor(u => u.ProcessedTimestamp, u => u.Date.Future(1, DateTime.Now))
                    .RuleFor(u => u.FileContent, Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonRecord)));
                var uploads = testUploads.Generate(8);

                foreach (Upload u in uploads)
                {
                    appDbContext.Uploads.Add(u);
                }
                appDbContext.SaveChanges();
            }

            if (!(appDbContext.Users.Any()))
            {
                var testUsers = new Faker<User>()
                    .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                    .RuleFor(u => u.LastName, u => u.Name.LastName())
                    .RuleFor(u => u.Username, u => u.Internet.UserName())
                    .RuleFor(u => u.Password, u => u.Internet.Password());
                var users = testUsers.Generate(4);

                User customUser = new User(){
                    FirstName = "Terry",
                    LastName = "Smith",
                    Username = "admin",
                    Password = "admin"
                };

                users.Add(customUser);

                foreach (User u in users)
                {
                    u.PasswordHash = BCrypt.Net.BCrypt.HashPassword(u.Password);
                    u.Password = "**********";
                    appDbContext.Users.Add(u);
                }
                appDbContext.SaveChanges();
            }
            if (!appDbContext.Roles.Any())
            {
                List<Role> roles = new List<Role>
                {
                    new Role() { Name = "Admin" },
                    new Role() { Name = "Operator" }
                }; 
                foreach (Role r in roles)
                {
                    appDbContext.Roles.Add(r);
                }
                appDbContext.SaveChanges();
                foreach (Role r in appDbContext.Roles)
                {
                    UserRole userRole = new UserRole()
                    {
                        RoleId = r.RoleId,  // This will now have a valid RoleId
                        UserId = appDbContext.Users.Where(x => x.Username == "admin").FirstOrDefault().Id
                    };
                    appDbContext.UserRoles.Add(userRole);
                }
                appDbContext.SaveChanges();
            }
            if (!appDbContext.Products.Any())
            {
                List<Product> products = new List<Product>
                {
                    new Product() { ProductName = "Lays",Price = 12,Description="Fromage",StockQuantity=2 },
                    new Product() { ProductName = "3Bit",Price = 12,Description="Small",StockQuantity=2 }
                };
                foreach (Product p in products)
                {
                    appDbContext.Products.Add(p);
                }
                appDbContext.SaveChanges();
            }
            if (!appDbContext.VendingMachines.Any())
            {
                List<VendingMachine> vendingMachines = new List<VendingMachine>
                {
                    new VendingMachine() { VendingMachineName = "MaszynaCzipsy",Capacity = 12,VendingMachineStatus="Fromage",Location="Zory",UserID=appDbContext.Users.Where(x => x.Username == "admin").FirstOrDefault().Id },
                    new VendingMachine() { VendingMachineName = "MaszynaBatony",Capacity = 12,VendingMachineStatus="Small",Location="WWa",UserID=appDbContext.Users.Where(x => x.Username == "admin").FirstOrDefault().Id }
                };
                foreach (VendingMachine p in vendingMachines)
                {
                    appDbContext.VendingMachines.Add(p);
                }
                appDbContext.SaveChanges();
            }
        }
    }
}