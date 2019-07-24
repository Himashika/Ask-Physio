using Physio.Data.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Physio.Data.Domain
{
    [Table("Doctor")]
    public class Doctor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(DbConstraints.NameLength)]
        public string FirstName { get; set; }
        [Required, StringLength(DbConstraints.NameLength)]
        public string LastName { get; set; }
        [Required, StringLength(DbConstraints.PhoneLength)]
        public int PhoneNo { get; set; }
        [StringLength(DbConstraints.NameLength)]
        public string Hospital { get; set; }//not requrd
        public string ImageUrl { get; set; }//not requrd
        public string Email { get; set; }
        public String Description { get; set; }
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public int UserId { get; set; }

        #region relations
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; protected set; }
        #endregion

        public Doctor Create(int id, string firstName, string lastName, int phoneNo, string hospital,
           string imageUrl, string email, string description, string registrationNo, string address, int gender)
        {
            UserId = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Hospital = hospital;
            ImageUrl = imageUrl;
            ImageUrl = imageUrl;
            Email = email;
            Description = description;
            RegistrationNo = registrationNo;
            Address = address;
            Gender = gender;
            return this;
        }
        public Doctor AddUser(User user)
        {
            User = user;

            return this;
        }
    }
}
