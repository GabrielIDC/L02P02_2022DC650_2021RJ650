namespace L02P02_2022DC650_2021RJ650.Models
{
    public class pedido_encabezado
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int cantidad_libros { get; set; }
        public decimal total { get; set; }
    }
}
