﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FriendOrganizer.Model
{
    public class Friend
    {
        //[Key] - EntityHandling automatically identifies the primary key
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public int? FavoriteLanguageId { get; set; }

        public ProgrammingLanguage FavoriteLanguage { get; set; }

        public ICollection<FriendPhoneNumber> PhoneNumbers { get; set; } = new Collection<FriendPhoneNumber>();

        public ICollection<Meeting> Meetings { get; set; } = new Collection<Meeting>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
