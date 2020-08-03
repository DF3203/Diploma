﻿namespace Server.DataBaseCore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Person : EntityDataType
    {
        [StringLength(450)]
        public string FirstName { get; set; }

        [StringLength(450)]
        public string LastName { get; set; }

        [StringLength(450)]
        public string MiddleName { get; set; }

        [StringLength(450)]
        public string Age { get; set; }

        [StringLength(450)]
        public string Weight { get; set; }

        [StringLength(450)]
        public string Height { get; set; }

        [StringLength(450)]
        public string Sex { get; set; }

        [StringLength(450)]
        public string PhoneNumber { get; set; }

        [StringLength(450)]
        public string HomeNumber { get; set; }

        [StringLength(450)]
        public string Email { get; set; }

        [StringLength(450)]
        public string Condition { get; set; }
    }
}
