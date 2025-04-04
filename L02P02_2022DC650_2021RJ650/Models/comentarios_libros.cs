namespace L02P02_2022DC650_2021RJ650.Models
{
    public class comentarios_libros
    {
        public int id { get; set; }
        public int id_libro { get; set; }
        public string comentarios { get; set; }
        public string usuario { get; set; }
        public DateTime created_at { get; set; }
    }
}
