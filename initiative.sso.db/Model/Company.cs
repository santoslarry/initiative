

namespace initiative.sso.db.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblCompany")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
