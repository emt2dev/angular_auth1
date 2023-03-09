using AngularAuthAPI.Models;
using System;
using System.Collections.Generic;

namespace AngularAuthAPI.DTOModels
{
    public class UserDTO
    {

        public int? usersId { get; set; }

        public string? usersFirstName { get; set; }

        public string? usersLastName { get; set; }

        public string? usersUsername { get; set; }

        public string? usersEmail { get; set; }

        public string? usersPassword { get; set; }

        public string? usersToken { get; set; }

        public string? usersRole { get; set; }

        public UserDTO(User givenUser)
        {
            this.usersUsername = givenUser.Username;
            this.usersEmail = givenUser.Email;

            this.usersFirstName = givenUser.FirstName;
            this.usersFirstName = givenUser.LastName;

            this.usersPassword = givenUser.Password;
            this.usersToken = givenUser.Token;
            this.usersRole = givenUser.Role;
        }
    }
}
