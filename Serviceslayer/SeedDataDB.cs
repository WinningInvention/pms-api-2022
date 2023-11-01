using Microsoft.AspNetCore.Identity;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer
{
    public class SeedDataDB
    {
        private readonly ApplicationDbContext _dbContext;

        public SeedDataDB(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRoles()
        {
            var roles = new List<IdentityRole>
                {

                    new IdentityRole {Name = "Admin",NormalizedName="ADMIN"},
                    new IdentityRole {Name = "Consultant",NormalizedName="CONSULTANT"},
                    new IdentityRole {Name = "Floor Cordinatior",NormalizedName="FLOOR CORDINATIOR"},
                    new IdentityRole {Name = "Part",NormalizedName="PART"},
                    new IdentityRole {Name = "Manager",NormalizedName="MANAGER"},
                };

            foreach (var userRoles in roles)
            {
                var existingValue = _dbContext.Roles.FirstOrDefault(cv => cv.Name == userRoles.Name);

                if (existingValue == null)
                {
                    _dbContext.Roles.Add(userRoles);
                }
            }

            _dbContext.SaveChanges();
        }

    }
}
