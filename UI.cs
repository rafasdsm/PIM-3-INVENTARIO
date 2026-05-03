using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PIM_3_INVENTARIO
{
    internal class UI
    {
        // lista todos os produtos
        public void ListarTudo(Inventario inventario)
        {
            Console.WriteLine("=== CATEGORIAS ===");
            inventario.ListarCategorias();
            Console.WriteLine("\n=== PRODUTOS NÃO PERECÍVEIS ===");
            inventario.ListarProdutos();
            Console.WriteLine("\n=== PRODUTOS PERECÍVEIS ===");
            inventario.ListarProdutosPereciveis();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        // lista os produtos pereciveis
        public void ListarProdutosPereciveis(Inventario inventario) {
            Console.WriteLine("\n=== PRODUTOS PERECÍVEIS ===");
            inventario.ListarProdutosPereciveis();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        // lista os produtos nao pereciveis
        public void ListarProdutos(Inventario inventario)
        {
            Console.WriteLine("\n=== PRODUTOS NÃO PERECÍVEIS ===");
            inventario.ListarProdutos();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        // lista as categorias
        public void ListarCategorias(Inventario inventario) {
            Console.WriteLine("=== CATEGORIAS ===");
            inventario.ListarCategorias();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        // cadastra os produtos
        public void CadastrarProdutos(Inventario inventario)
        {
            Console.WriteLine("=== Cadastrar Produto ===");
            string nome_produto;

            // nome do produto
            while (true){
                Console.WriteLine("Nome do produto:");
                nome_produto = Console.ReadLine();
                if(!String.IsNullOrWhiteSpace(nome_produto)) {
                    break;
                }
            }
            string descricao = string.Empty;
            // descrição do produto
            while (true)
            {
                Console.WriteLine("Descrição do produto:");
                descricao = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    // Se a descrição for válida, sai do laço
                    break;
                }

                Console.WriteLine("Erro: A descrição não pode ser vazia! Tente novamente.");
            }
            string categoria_num;
            int categoria_index;
            Categoria cat;
            // categoria do produto
            while (true)
            {
                inventario.ListarCategorias();
                Console.WriteLine("Qual a categoria do produto[ID]?");
                categoria_num = Console.ReadLine();
                if (int.TryParse(categoria_num, out categoria_index)){
                    categoria_index = int.Parse(categoria_num);
                    cat = inventario.lista_categorias[categoria_index-1];
                    break;
                }
  
            }
            int quantidade;
            // quantidade do produto
            while(true)
            {
                Console.WriteLine("Quantidade do produto no estoque:");
                string qnt = Console.ReadLine();
                if(int.TryParse(qnt, out quantidade))
                {
                    quantidade = int.Parse(qnt);
                    break;
                }
                else
                {
                    Console.WriteLine("Coloque um valor válido");
                }
            }
            bool perecivel;
            // verifica se ele é perecível ou não
            while (true)
            {
                Console.WriteLine("Esse produto é perecível?[s/n]: ");
                string option = Console.ReadLine();
                if(option == "s")
                {
                    perecivel = true;
                    break;
                }
                if(option == "n")
                {
                    perecivel = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                }
            }
            // se for, pede a data de validade do mesmo
            DateTime result;
            if(perecivel)
            {
                while (true)
                {
                    Console.WriteLine("Digite a data de validade [dia/mes/ano]: ");
                    string data = Console.ReadLine();
                    try
                    {
                        result = DateTime.Parse(data);
                        break;
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Data inválida");
                    }
                }
                // cadastra o produto como produto perecível
                ProdutoPerecivel produto = new ProdutoPerecivel()
                {
                    Id=inventario.lista_produtos.Count()+inventario.lista_produtosp.Count()+1,
                    Category = cat,
                    Description = descricao,
                    Name = nome_produto,
                    Qnt = quantidade,
                    Validade = result
                    
                };
                inventario.CadastrarProdutoPerecivel(produto);
                Console.WriteLine("Produto Cadastrado!");
            }
            // cadastra o produto como não perecível
            else
            {
                Produto produto = new Produto()
                {
                    Qnt = quantidade,
                    Category = cat,
                    Description = descricao,
                    Name = nome_produto,
                    Id = inventario.lista_produtos.Count() + inventario.lista_produtosp.Count() + 1
                };
                inventario.CadastrarProduto(produto);
                Console.WriteLine("Produto Cadastrado!");

            }

        }
        public void RemoverProduto(Inventario inventario) {
            while(true)
                {
                Console.WriteLine("=== PRODUTOS ===");
                ListarProdutos(inventario);
                ListarProdutosPereciveis(inventario);
                Console.WriteLine("Digite o ID do produto a ser removido:");
                string nomeProduto = Console.ReadLine();
                if (int.TryParse(nomeProduto, out int id))
                {
                    inventario.RemoverProduto(id);
                    break;
                }
                else
                {
                    Console.WriteLine("ID inválido.\n\n");
                }
            }
        }
        public void ListarVencidos(Inventario inventario) {
            Console.WriteLine("\n=== PRODUTOS VENCIDOS ===");
            inventario.ListarVencidos();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }


        public void Escolhas(Inventario inventario) {
            while (true)
            {
                Console.WriteLine("==== INVENTÁRIO ====");
                Console.WriteLine("1 - Listar produtos não perecíveis, categorias e produtos perecíveis");
                Console.WriteLine("2 - Listar produtos não perecíveis");
                Console.WriteLine("3 - Listar produtos perecíveis");
                Console.WriteLine("4 - Listar produtos por categoria");
                Console.WriteLine("5 - Listar produtos vencidos");
                Console.WriteLine("6 - Remover produto");
                Console.WriteLine("7 - Adicionar produto");
                string escolha = Console.ReadLine();
                switch (escolha) {
                    case "1":
                        Console.WriteLine("\n\n");
                        ListarTudo(inventario);
                        break;
                    case "2":
                        Console.WriteLine("\n\n");

                        ListarProdutosPereciveis(inventario);
                        break;
                    case "3":
                        Console.WriteLine("\n\n");

                        ListarProdutosPereciveis(inventario);
                        break;
                    case "4":
                        Console.WriteLine("\n\n");

                        ListarCategorias(inventario);
                        break;
                    case "5":
                        Console.WriteLine("\n\n");

                        ListarVencidos(inventario);
                        break;
                    case "6":
                        Console.WriteLine("\n\n");

                        RemoverProduto(inventario);
                        break;
                    case "7":
                        Console.WriteLine("\n\n");

                        CadastrarProdutos(inventario);
                        break;
                    default:
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Opção inválida!"); break;
                }
            }
        }
    }
}
