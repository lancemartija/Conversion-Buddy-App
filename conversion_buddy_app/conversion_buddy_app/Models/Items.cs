using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace conversion_buddy_app.Models
{
    [Table("list")]
    public class Items
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Item { get; set; }
    }
}
