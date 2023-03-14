using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore_MariaDB.Data.Models
{
    [Table("Clients")]
    public class Client
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Telefone { get; set; }
    public List<Adresses> Enderecos { get; set; }
}
}
