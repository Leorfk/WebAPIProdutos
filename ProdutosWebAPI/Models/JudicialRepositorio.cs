using ProdutosWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebAPI.Models
{
    public class JudicialRepositorio : IJudicialRepositorio
    {
        private List<Judicial> judicials = new List<Judicial>();
        private int _NextId = 1;
        public JudicialRepositorio()
        {
            Add(new Judicial { Nome = "Google", CNPJ = "53.206.581/0001-89", DataDeposito = new DateTime(2019, 05, 13, 12, 11, 53) ,ValorDeposito = 20000000.00M });
            Add(new Judicial { Nome = "Facebook", CNPJ = "53.204.512/0001-90", DataDeposito = new DateTime(2019, 03, 11, 11, 35, 01), ValorDeposito = 150000000.00M });
            Add(new Judicial { Nome = "Carambola", CNPJ = "33.211.611/0001-32", DataDeposito = new DateTime(2019, 02, 02, 10, 17, 00), ValorDeposito = 1000000.00M });
            Add(new Judicial { Nome = "Amazon", CNPJ = "11.224.111/0001-12", DataDeposito = new DateTime(2019, 01, 01, 15, 53, 17), ValorDeposito = 20000000.00M });
            Add(new Judicial { Nome = "Toyota", CNPJ = "51.216.068/0001-34", DataDeposito = new DateTime(2019, 02, 07, 13, 27, 42), ValorDeposito = 24000000.00M });
        }

        public Judicial Add(Judicial judicial)
        {
            if (judicial == null)
            {
                throw new ArgumentException("Erro ao adicionar");
            }
            judicial.Id = _NextId++;
            judicials.Add(judicial);
            return judicial;
        }

        public Judicial Get(int id)
        {
            return judicials.Find(j => j.Id == id);
        }

        public IEnumerable<Judicial> GetAll()
        {
            return judicials;
        }

        public void Remove(int id)
        {
            judicials.RemoveAll(j => j.Id == id);
        }

        public bool Update(Judicial judicial)
        {
            if (judicial == null)
            {
                throw new ArgumentException("Erro ao remover o produto");
            }
            int index = judicials.FindIndex(j => j.Id == judicial.Id);
            if (index == -1)
            {
                return false;
            }
            judicials.RemoveAt(index);
            judicials.Add(judicial);
            return true;
        }
    }
}
