namespace VeloEventsManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppRole
    {
        public AppRole(string name)
            : this()
        {
            this.Name = name;
        }

        public AppRole()
        {
            this.Name = "";
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
