using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace initiative.sso.db.Model
{
    [Table("tblUserRoles")]
    public class UserRoles
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role
        /// </summary>
        public Roles Roles { get; set; }

        /// <summary>
        /// Gets or sets the user
        /// </summary>
        public Users Users { get; set; }
    }
}
