using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_3_INVENTARIO
{
    internal class Inventario
    {
        public List<Categoria> lista_categorias = new List<Categoria>();
        public List<Produto> lista_produtos = new List<Produto>();
        public List<ProdutoPerecivel> lista_produtosp = new List<ProdutoPerecivel>();

        public void CadastrarCategoria(Categoria categoria)
        {
            lista_categorias.Add(categoria);
        }

        public void CadastrarProduto(Produto produto)
        {
            lista_produtos.Add(produto);
        }

        public void CadastrarProdutoPerecivel(ProdutoPerecivel produtoPerecivel)
        {
            lista_produtosp.Add(produtoPerecivel);
        }

        public void ListarCategorias()
        {
            foreach (var categoria in lista_categorias)
            {
                Console.WriteLine($"ID: {categoria.categoriaid}, Nome: {categoria.categorianame}");
            }
        }

        public void ListarProdutos()
        {
            foreach (var produto in lista_produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Name}, Categoria: {produto.Category.categorianame}");
            }
        }
        public void ListarProdutosPereciveis()
        {
            foreach (var produto in lista_produtosp)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Name}, Categoria: {produto.Category.categorianame}, Validade: {produto.Validade.ToShortDateString()}, Vencido: {(produto.Vencido ? "Sim" : "Não")}");
            }
        }
        public void RemoverProduto(int id)
        {
            var produto = lista_produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                lista_produtos.Remove(produto);
                Console.WriteLine($"Produto com ID {id} removido.");
                return;
            }
            var produtoPerecivel = lista_produtosp.FirstOrDefault(p => p.Id == id);
            if (produtoPerecivel != null)
            {
                lista_produtosp.Remove(produtoPerecivel);
                Console.WriteLine($"Produto perecível com ID {id} removido.");
                return;
            }
            Console.WriteLine($"Produto com ID {id} não encontrado.");
        }
        public void ListarVencidos()
        {
            foreach(var produto in lista_produtosp.Where(p => p.Vencido))
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Name}, Categoria: {produto.Category.categorianame}, Validade: {produto.Validade.ToShortDateString()}");
            }
        }
        public void RemoverCategoria(int id)
        {
            var categoria = lista_categorias.FirstOrDefault(c => c.categoriaid == id);
            if (categoria != null)
            {
                // Remove produtos associados à categoria
                lista_produtos.RemoveAll(p => p.Category.categoriaid == id);
                lista_produtosp.RemoveAll(p => p.Category.categoriaid == id);
                lista_categorias.Remove(categoria);
                Console.WriteLine($"Categoria com ID {id} e seus produtos associados foram removidos.");
            }
            else
            {
                Console.WriteLine($"Categoria com ID {id} não encontrada.");
            }
        }
     
    }
}
