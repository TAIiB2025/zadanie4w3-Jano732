namespace WebAPI.Models
{
    public class FilmBody
    {
        public string Tytul { get; set; } = string.Empty;
        public string Rezyser { get; set; } = string.Empty;
        public string Gatunek { get; set; } = string.Empty;
        public int Rok_wydania { get; set; }
    }
}
