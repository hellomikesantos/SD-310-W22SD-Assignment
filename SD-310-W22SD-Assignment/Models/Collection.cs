using System;
using System.Collections.Generic;

namespace SD_310_W22SD_Assignment.Models
{
    public partial class Collection
    {
        public int? UserId { get; set; }
        public int? SongId { get; set; }
        public int Id { get; set; }

        public virtual Song? Song { get; set; }
        public virtual User? User { get; set; }
    }
}
