using AngularAuthAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.DTOModels
{
    public class UserDTO
    {
        public int usersId { get; set; }
        public string usersFirstName { get; set; }

        public string usersLastName { get; set; }

        public string usersUsername { get; set; }

        public string usersEmail { get; set; }

        public string usersPassword { get; set; }

        public string usersToken { get; set; }

        public string usersRole { get; set; }

        public UserDTO(User givenUserObj)
        {
            this.usersId = givenUserObj.Id;

            this.usersFirstName = givenUserObj.FirstName;
            this.usersLastName = givenUserObj.LastName;
            this.usersUsername = givenUserObj.Username;
            this.usersPassword = givenUserObj.Password;

            this.usersToken = givenUserObj.Token;
            this.usersRole = givenUserObj.Role;
        }
        /*
        public UserDTO(int givenUserId, string givenUserFN, string givenUserLn, string givenUsername, 
            string givenPassword, string givenUserToken, string givenUserRole) 
        {
            this.usersId = givenUserId;

            this.usersFirstName = givenUserFN;
            this.usersLastName = givenUserLn;
            this.usersUsername = givenUsername;
            this.usersPassword = givenPassword;

            this.usersToken = givenUserToken;
            this.usersRole = givenUserRole;
        }
        */
    }
}
