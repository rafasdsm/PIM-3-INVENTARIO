using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PIM_3_INVENTARIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // inicializa o inventário e cria as categorais e produtos
            Inventario inventario = new Inventario();

            Categoria catGraos = new Categoria()
            {
                categoriaid = 1,
                categorianame = "Grãos e Pós"
            };
            Categoria catDesc = new Categoria()
            {
                categoriaid = 2,
                categorianame = "Descartáveis"
            };
            Categoria catLaticinio = new Categoria()
            {
                categoriaid = 3,
                categorianame = "Laticínios"
            };
            Categoria catPadaria = new Categoria()
            {
                categoriaid = 4,
                categorianame = "Padaria"
            };

            List<Categoria> categorias = new List<Categoria> {
                catGraos,catDesc,catLaticinio,catPadaria
            };

            // --- 10 PRODUTOS NÃO PERECÍVEIS ---
            List<Produto> naoPereciveis = new List<Produto>
            {
                new Produto { Id = 1, Name = "Café Gourmet 1kg", Description = "Torra Média-Escura", Qnt = 40, Category = catGraos },
                new Produto { Id = 2, Name = "Açúcar Sachê", Description = "Caixa com 1000un", Qnt = 10, Category = catGraos },
                new Produto { Id = 3, Name = "Copo Papel 200ml", Description = "Biodegradável", Qnt = 500, Category = catDesc },
                new Produto { Id = 4, Name = "Filtro de Papel", Description = "Tamanho V60-02", Qnt = 15, Category = catDesc },
                new Produto { Id = 5, Name = "Mexedor de Madeira", Description = "Pacote com 500un", Qnt = 20, Category = catDesc },
                new Produto { Id = 6, Name = "Guardanapo", Description = "Folha Dupla", Qnt = 100, Category = catDesc },
                new Produto { Id = 7, Name = "Chocolate em Pó", Description = "Cacau 50%", Qnt = 12, Category = catGraos },
                new Produto { Id = 8, Name = "Xarope Baunilha", Description = "Garrafa 750ml", Qnt = 6, Category = catGraos },
                new Produto { Id = 9, Name = "Canudo de Papel", Description = "Embalado individualmente", Qnt = 1000, Category = catDesc },
                new Produto { Id = 10, Name = "Adoçante Líquido", Description = "Frasco 100ml", Qnt = 25, Category = catGraos }
            };

            // --- 10 PRODUTOS PERECÍVEIS ---
            List<ProdutoPerecivel> pereciveis = new List<ProdutoPerecivel>
            {
                new ProdutoPerecivel { Id = 11, Name = "Leite Integral", Description = "Caixa UHT 1L", Qnt = 60, Category = catLaticinio, Validade = new DateTime(2026, 08, 20) },
                new ProdutoPerecivel { Id = 12, Name = "Leite de Aveia", Description = "Edição Barista", Qnt = 12, Category = catLaticinio, Validade = new DateTime(2026, 07, 15) },
                new ProdutoPerecivel { Id = 13, Name = "Chantilly", Description = "Creme de leite fresco", Qnt = 8, Category = catLaticinio, Validade = new DateTime(2026, 06, 10) },
                new ProdutoPerecivel { Id = 14, Name = "Croissant", Description = "Congelado", Qnt = 100, Category = catPadaria, Validade = new DateTime(2026, 12, 01) },
                new ProdutoPerecivel { Id = 15, Name = "Pão de Queijo", Description = "Saca de 2kg", Qnt = 10, Category = catPadaria, Validade = new DateTime(2025, 11, 15) },
                new ProdutoPerecivel { Id = 16, Name = "Bolo de Laranja", Description = "Artesanal", Qnt = 4, Category = catPadaria, Validade = new DateTime(2026, 05, 10) },
                new ProdutoPerecivel { Id = 17, Name = "Manteiga", Description = "Tablete 500g", Qnt = 15, Category = catLaticinio, Validade = new DateTime(2023, 09, 30) },
                new ProdutoPerecivel { Id = 18, Name = "Cream Cheese", Description = "Pote Profissional", Qnt = 5, Category = catLaticinio, Validade = new DateTime(2026, 06, 25) },
                new ProdutoPerecivel { Id = 19, Name = "Suco de Laranja", Description = "Integral 1L", Qnt = 20, Category = catLaticinio, Validade = new DateTime(2026, 05, 15) },
                new ProdutoPerecivel { Id = 20, Name = "Sanduíche Natural", Description = "Frango com maionese", Qnt = 12, Category = catPadaria, Validade = new DateTime(2025, 05, 05) }
            };


            // adiciona no inventário as categorias e produtos criados
            foreach (var cat in categorias)
            {
                inventario.CadastrarCategoria(cat);
            }

            foreach (var prod in naoPereciveis)
            {
                inventario.CadastrarProduto(prod);
            }
            foreach (var prod in pereciveis)
            {
                inventario.CadastrarProdutoPerecivel(prod);
            }
    
            UI ui = new UI();
            ui.Escolhas(inventario);
        }
    }
}
