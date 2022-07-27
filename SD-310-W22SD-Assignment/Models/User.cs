using System;
using System.Collections.Generic;

namespace SD_310_W22SD_Assignment.Models
{
    public partial class User
    {
        public User()
        {
            Collections = new HashSet<Collection>();
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? SongId { get; set; }
        public int? Wallet { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
