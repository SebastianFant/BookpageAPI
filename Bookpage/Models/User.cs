using System;
using System.Collections.Generic;

namespace Bookpage.Models
{
    public partial class User
    {
        public User()
        {
            Quotes = new HashSet<Quote>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
