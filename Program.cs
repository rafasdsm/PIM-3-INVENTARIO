using System.IO;
using System.Text.Json;

namespace PIM_3_INVENTARIO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Inventário_UI inventario = new Inventário_UI();
            
            Produto produto = new Produto
            {
                Category = "Bebida",
                Description = "",
                Name = "Coca-cola",
                Id = 0,
                Qnt = 20
            };

            // tutorial de como usar o System.Text.Json para serializar um objeto em um arquivo json
            //https://www.youtube.com/watch?v=w6M-Bj-tfv4

            File.WriteAllText("database.json", "");
            string jsonstring = JsonSerializer.Serialize(produto);
            File.WriteAllText("database.json", jsonstring);

        }
    }
}
