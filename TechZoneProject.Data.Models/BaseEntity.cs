using System;
using System.ComponentModel.DataAnnotations;

namespace TechZoneProject.Data.Models
{
   
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }      

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}