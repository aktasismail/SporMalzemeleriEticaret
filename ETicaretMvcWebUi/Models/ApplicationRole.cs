using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class ApplicationRole:IdentityRole
    {
        public string Detay { get; set; }
        public ApplicationRole()
        {
            
        }
        public ApplicationRole(string roladi,string detay)
        {
            this.Detay = detay;
        }
    }
}