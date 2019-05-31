using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebAPI.Models
{
    public class Judicial
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public decimal ValorDeposito { get; set; }
        public DateTime DataDeposito { get; set; }
    }
}
