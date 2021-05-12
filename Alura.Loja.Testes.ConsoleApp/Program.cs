using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            //GravarUsandoAdoNet();  
            //RcuperarProdutos();
            //ExcluirProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            //inclui um produto
            GravarUsandoEntity();
            RcuperarProdutos();

            //atualiza o produto
            using (var repo = new produtoDAOEntity())
            {
                Produto produtos = repo.Produtos().First();
                produtos.Nome = "Ele foi editado";
                repo.Atualizar(produtos);
            }

            RcuperarProdutos();

        }

        private static void ExcluirProdutos()
        {
           using (var repo = new produtoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos().ToList();
                foreach (var item in produtos)
                {
                    repo.Remover(item);
                   
                }

            }
        }

        private static void RcuperarProdutos()
        {
            using (var repo = new produtoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos().ToList();
                Console.WriteLine("Foram encontrados {0} produtos", produtos.Count());

                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                    Console.ReadLine();
                }

            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new produtoDAOEntity())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
