namespace PIM_3_INVENTARIO
{
    internal class Categoria
    {
        private int _categoriaid { get; set; }
        private string _categorianame { get; set; }

        public int categoriaid
        {
            get { return _categoriaid; }
            set { if (value >= 0) _categoriaid = value; }
        }

        public string categorianame
        {
            get { return _categorianame; }
            set { if (!string.IsNullOrEmpty(value)) _categorianame = value; }
        }
    }
}
