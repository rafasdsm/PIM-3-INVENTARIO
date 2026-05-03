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
    }
}
