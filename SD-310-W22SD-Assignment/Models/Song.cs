using System;
using System.Collections.Generic;

namespace SD_310_W22SD_Assignment.Models
{
    public partial class Song
    {
        public Song()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int ArtistId { get; set; }
        public int? UserId { get; set; }

        public virtual Artist Artist { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
