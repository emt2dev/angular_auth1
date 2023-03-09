using AngularAuthAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.DTOModels
{
    public class CreateUserDTO
    {
        public string? usersFirstName { get; set; }

        public string? usersLastName { get; set; }

        [Required] // requires a username
        public string? usersUsername { get; set; }

        public string? usersEmail { get; set; }

        public string? usersPassword { get; set; }

        public string? usersToken { get; set; }

        public string? usersRole { get; set; }
    }
    public class UserDTO : CreateUserDTO
    {

        public int? usersId { get; set; }

        public IList<UserDTO> users { get; set;}

    }
}
