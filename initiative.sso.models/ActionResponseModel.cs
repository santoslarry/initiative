using System;
using System.Collections.Generic;
using System.Text;

namespace initiative.sso.models
{
    public class ActionResponseModel
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the Error
        /// </summary>
        public string Error { get; set; }
    }
}
