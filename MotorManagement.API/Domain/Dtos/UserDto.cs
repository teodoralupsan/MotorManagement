using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// Property of type integer that contains the Id of user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property of type string that contains the UserName of user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Property of type string that contains the Roles of user.
        /// </summary>
        public IList<string> Roles { get; set; }
    }
}
