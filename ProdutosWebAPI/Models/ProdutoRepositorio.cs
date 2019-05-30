using ProdutosWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebAPI.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> Produtos = new List<Produto>();
        private int _nextId = 1;
        public ProdutoRepositorio()
        {
            Add(new Produto { Nome = "Suco de laranja", Categoria = "Bebidas", Preco = 1.90M });
            Add(new Produto { Nome = "Arroz 5kg", Categoria = "Grãos", Preco = 14.90M });
            Add(new Produto { Nome = "Feijão 1kg", Categoria = "Grãos", Preco = 4.30M });
            Add(new Produto { Nome = "Coca-Cola", Categoria = "Bebidas", Preco = 8.80M });
            Add(new Produto { Nome = "Frango", Categoria = "Carnes", Preco = 11.90M });
        }

        public Produto Add(Produto model)
        {
            if (model == null)
            {
                throw new ArgumentException("Item não encontrado");
            }
            model.Id = _nextId++;
            Produtos.Add(model);
            return model;
        }

        public Produto Get(int id)
        {
            //lambda faz a comparação entre os IDS
            return Produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return Produtos;
        }

        public void Remove(int id)
        {
            Produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto model)
        {
            if (model == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }
            int index = Produtos.FindIndex(p => p.Id == model.Id);
            if (index ==-1)
            {
                //validação para produto não encontrado
                return false;
            }
            Produtos.RemoveAt(index);
            Produtos.Add(model);
            return true;
        }
    }
}
