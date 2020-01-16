using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kelolakeuangan.Models
{
    public class Account
    {
     
        [Key]
        public int Id_Account { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }
        
        public int? Id_Family { get; set; }


        public ICollection<Income> Incomes { get; set; }

        public ICollection<Wallet> Wallets { get; set; }

        public ICollection<Spending> Spendings { get; set; }

    }
}
