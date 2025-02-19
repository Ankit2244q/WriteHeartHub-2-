using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Doman.Entities
{
    public class Shayri
    {
        public int Sharimsg_id { get; set; }  // Primary Key
        public int AccountID { get; set; }    // User Account ID AccountID
        public string Shayritext { get; set; } // Shayri Content
        public bool IsDelete { get; set; }    // Soft Delete Flag
    }
}
//Sharimsg_id,AccountID,Shayritext,IsDelete