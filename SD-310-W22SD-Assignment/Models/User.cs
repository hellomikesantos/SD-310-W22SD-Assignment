using System;
using System.Collections.Generic;

namespace SD_310_W22SD_Assignment.Models
{
    public partial class User
    {
        public User()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? SongId { get; set; }

        public virtual Song? Song { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
