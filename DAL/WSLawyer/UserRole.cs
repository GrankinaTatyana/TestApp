using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class UserRole
    {
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public long Id { get; set; }

        public virtual User User { get; set; }
    }
}
