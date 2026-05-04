using System;

namespace PIM_3_INVENTARIO
{
    internal class Produto
    {

        public int Id { get; set; }

        private string name = string.Empty;
        private string description = "Produto sem descrição";
        private int qnt;
        private Categoria category = null;
        public bool disponivel => qnt >0;

        public string Name
        {
            get => name;
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }

        public string Description
        {
            get => description;
            set { if (!string.IsNullOrWhiteSpace(value)) description = value; }
        }

        public int Qnt
        {
            get => qnt;
            set { if (value >= 0) qnt = value; }
        }

        public Categoria Category
        {
            get => category;
            set { if (value != null) category = value; }
        }
    }

    internal class ProdutoPerecivel : Produto
    {
        public DateTime Validade { get; set; }
        public bool Vencido => DateTime.Now > Validade;
    }
}