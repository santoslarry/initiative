

namespace initiative.sso.db.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblTest")]
    public class Tests
    {
        [Key]
        public int Id { get; set; }

    }
}
