namespace CrudTransaccion.Models
{
    public class Libro
    {
        public int Libroid { get; set; }
        public string Titulo { get; set; }
        public int Paginas { get; set; }
        public Genero genero { get; set; }
        public Autor autor { get; set; }
    }
}
