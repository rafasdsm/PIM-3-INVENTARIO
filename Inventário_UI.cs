using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PIM_3_INVENTARIO
{
    internal class Inventário_UI
    {
        List<Produto> lista_produtos = new List<Produto>();
        List<ProdutoPerecivel> lista_pereciveis = new List<ProdutoPerecivel>();
        List<Categoria> lista_categorias = new List<Categoria>();

        public void CadastrarCategoria()
        {
            string nome = "";
            Console.WriteLine("----------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Nome da categoria:  ");
                string _nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(_nome))
                {
                    nome = _nome;
                    Categoria categoria = new Categoria();
                    categoria.categorianame = nome;
                    categoria.categoriaid = lista_categorias.Count + 1;
                    lista_categorias.Add(categoria);
                    Console.WriteLine($"Categoria {categoria.categorianame} adicionada com ID: {categoria.categoriaid}");
                    break;
                }
                else
                {
                    Console.WriteLine("Adicione um nome à categoria!");
                }
            }
        }

        public void CadastrarProduto()
        {
            string nome = "";
            string desc = "";
            int qnt = 0;
            Categoria categoria = new Categoria();
            DateTime validade;

            // nome do produto
            Console.WriteLine("----------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Nome do produto:  ");
                string _nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(_nome))
                {
                    _nome = nome;
                    break;
                }
                else
                {
                    Console.WriteLine("Adicione um nome ao produto!");
                }
            }

            // Adiciona descrição ao produto
            Console.WriteLine("----------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Descrição do Produto[opcional]:  ");
                string _desc = Console.ReadLine();
                if (!String.IsNullOrEmpty(_desc))
                {
                    _desc = desc;
                    break;
                }
                else
                {
                    string _sair = "";
                    while (_sair != "s" && _sair != "n")
                    {
                        Console.WriteLine("Adicionar produto sem descrição?[s/n]");
                        _sair = Console.ReadLine();
                    }
                    Console.WriteLine("Produto Adicionado sem descrição!");
                    break;
                }
            }

            // Adiciona quantidade ao produto
            Console.WriteLine("----------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Quantidade do produto no estoque:  ");
                string _qnt = Console.ReadLine();
                if (!int.TryParse(_qnt, out qnt))
                {
                    Console.WriteLine("Digite um número inteiro para a quantidade do produto!");
                }
                else
                {
                    int.TryParse(_qnt, out qnt);
                    break;
                }
            }

            // Adiciona categoria ao produto
            Console.WriteLine("----------------------------------------------------------");
            while (true)
            {
                foreach (var cats in lista_categorias)
                {
                    Console.WriteLine($"ID: {cats.categoriaid} - Nome: {cats.categorianame}");
                }
                Console.WriteLine("Categoria do produto[número]:  ");
                string _categoria = Console.ReadLine();
                int _catindex = 0;
                if (!String.IsNullOrEmpty(_categoria))
                {
                    int.TryParse(_categoria, out _catindex);
                    //adicionar uma forma de adicionar outras categorias aqui caso não haja na lista

                    // verificar se a categoria existe na lista de categorias
                    if (_catindex <= lista_categorias.Count)
                    {
                        {
                            categoria.categoriaid = lista_categorias[_catindex - 1].categoriaid;
                            categoria.categorianame = lista_categorias[_catindex - 1].categorianame;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Adicione uma categoria ao produto!");
                    }
                }
            }

            // Verifica se o produto é perecível

            while (true)
            {
                Console.WriteLine("O produto é perecível?[s/n]");
                string _perecivel = Console.ReadLine();
                if (_perecivel == "s")
                {
                    while (true)
                    {
                        Console.WriteLine("Data de validade do produto[dd/mm/aaaa]:  ");
                        string _validade = Console.ReadLine();
                        if (!DateTime.TryParse(_validade, out validade))
                        {
                            Console.WriteLine("Digite uma data válida para a validade do produto!");
                        }
                        else
                        {
                            DateTime.TryParse(_validade, out validade);
                            ProdutoPerecivel produto_perecivel = new ProdutoPerecivel()
                            {
                                Id = lista_produtos.Count + 1,
                                Name = nome,
                                Description = desc,
                                Qnt = qnt,
                                Category = categoria.categorianame,
                                Validade = validade
                            };
                            lista_pereciveis.Add(produto_perecivel);
                            Console.WriteLine("Produto adicionado ao estoque!");
                            break;
                        }
                    }
                    break;
                }
                else if (_perecivel == "n")
                {
                    Produto produto = new Produto()
                    {
                        Id = lista_produtos.Count + 1,
                        Name = nome,
                        Description = desc,
                        Qnt = qnt,
                        Category = categoria.categorianame
                    };
                    lista_produtos.Add(produto);
                    Console.WriteLine("Produto adicionado ao estoque!");
                    break;
                }
                else
                {
                    Console.WriteLine("Digite 's' para sim ou 'n' para não!");
                }
            }

        }

        public void ListarProdutos()
        {
            foreach (var produto in lista_produtos)
            {
                Console.WriteLine($"ID: {produto.Id} - Nome: {produto.Name} - Descrição: {produto.Description} - Quantidade: {produto.Qnt} - Categoria: {produto.Category}");
            }
        }
        public void ListarPereciveis()
        {
            foreach (var produto in lista_pereciveis)
            {
                Console.WriteLine($"ID: {produto.Id} - Nome: {produto.Name} - Descrição: {produto.Description} - Quantidade: {produto.Qnt} - Categoria: {produto.Category} - Validade: {produto.Validade.ToShortDateString()} - Vencido: {(produto.Vencido ? "Sim" : "Não")}");
            }
        }
        public void ListarCategorias()
        {
            foreach (var categoria in lista_categorias)
            {
                Console.WriteLine($"ID: {categoria.categoriaid} - Nome: {categoria.categorianame}");
            }
        }
        public void ListarTodos()
        {
            ListarProdutos();
            ListarPereciveis();
        }
        public void ListarVencidos()
        {
            foreach (var produto in lista_pereciveis)
            {
                if (produto.Vencido)
                {
                    Console.WriteLine($"ID: {produto.Id} - Nome: {produto.Name} - Descrição: {produto.Description} - Quantidade: {produto.Qnt} - Categoria: {produto.Category} - Validade: {produto.Validade.ToShortDateString()} - Vencido: Sim");
                }
            }
        } 
        }
}