using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace ApiAppWithSwagger.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Database ID
        /// </summary>
        public long Id {get; set;}

        /// <summary>
        /// Todo name
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// Todo value
        /// </summary>
        public string value { get; set; }

    }
}
