using System;
using System.Collections.Generic;

namespace Bookpage.Models
{
    public partial class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int User { get; set; }

        public virtual User UserNavigation { get; set; } = null!;
    }
}
