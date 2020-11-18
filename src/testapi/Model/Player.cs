using System;

namespace Model
{
    public class Player
    {
        public virtual string Username { get; set; }

        public virtual DateTime Joined { get; set; }

        public virtual string Email { get; set; }
    }
}
