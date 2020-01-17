using System.ComponentModel.DataAnnotations;

namespace kelolakeuangan.Models
{
    public class Wallet
    {
        [Key]
        public int Id_Wallet { get; set; }

        public string Name { get; set; }

        public double Limit { get; set; }

        //public int Id_Account { get; set; }

        //public Account Account { get; set; }

        //public ICollection<Spending> Spendings { get; set; }

    }
}
