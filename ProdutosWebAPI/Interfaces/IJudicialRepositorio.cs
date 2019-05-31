using ProdutosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebAPI.Interfaces
{
    public interface IJudicialRepositorio
    {
        IEnumerable<Judicial> GetAll();
        Judicial Get(int id);
        Judicial Add(Judicial judicial);
        bool Update(Judicial judicial);
        void Remove(int id);
    }
}
