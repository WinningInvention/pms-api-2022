using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ApplicationUser : IdentityUser
    {   
        public string Gender { get; set; }
        public string NadicsNumber { get; set; }
        public string Position { get; set; }
    }
}
