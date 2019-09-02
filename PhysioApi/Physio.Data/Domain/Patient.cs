using Physio.Data.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physio.Data.Domain
{
    [Table("Patient")]
    public class Patient : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(DbConstraints.NameLength)]
        public string FirstName { get; set; }
        [Required, StringLength(DbConstraints.NameLength)]
        public string LastName { get; set; }
        [Required, StringLength(DbConstraints.PhoneLength)]
        public string PhoneNo { get; set; }
        [Required, StringLength(DbConstraints.AddressLength)]
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public int UserId { get; set; }

        #region relations
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; protected set; }
        #endregion

        public Patient Create(int id, string firstName, string lastName, string phoneNo,
         string imageUrl, string email, string address, int gender)
        {
            UserId = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            ImageUrl = imageUrl;
            Email = email;
            Address = address;
            Gender = gender;
            return this;
        }

        public Patient AddUser(User user)
        {
            User = user;
            return this;
        }
    }
}
