using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace initiative.sso.db.Model
{
    [Table("tblUsers")]
    public class Users
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string UserEmail { get; set; }

        public Company Company { get; set; }
    }
}
