using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DomainPlayer = Model.Player;

namespace Repository.Entities
{
    public class Player : DomainPlayer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public override string Username { get; set; }

        public override DateTime Joined { get; set; }

        public override string Email { get; set; }
    }
}
