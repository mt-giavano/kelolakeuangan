using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kelolakeuangan.Models
{
    public class Income
    {
        [Key]
        public int Id_Income { get; set; }

        public DateTime Date { get; set; }
        
        public double Amount { get; set; }

        public string Note { get; set; }

        //public int Id_Account { get; set; }

        //public Account Account { get; set; }


    }
}
