using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class User
    {
      

        public long Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsAsv { get; set; }
        public long RegionId { get; set; }

      }
 
      
    
}
