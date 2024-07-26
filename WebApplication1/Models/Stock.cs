using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace WebApplication1.Models
{
    public class Stock
    {
        public int id { get; set; }
        public string symbol { get; set; } = String.Empty;
        public string CompanyName { get; set; } = String.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = String.Empty;
        public long MarketCap { set; get; } 
        public List<Comment> Comments { get; set; } = new List<Comment>();
        

        
    }
}
 