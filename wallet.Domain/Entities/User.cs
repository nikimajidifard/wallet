using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserRole { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public IEnumerable<WalletE> Wallets { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
    }
}
