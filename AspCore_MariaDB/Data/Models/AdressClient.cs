using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore_MariaDB.Data.Models
{
    [Table("AdressClient")]
    public class AdressClient
{
     [Key]
    public int ClientId { get; set; }
    public Client Clients { get; set; }
    public int AdressesId { get; set; }
    public Adresses Adress { get; set; }
}
}