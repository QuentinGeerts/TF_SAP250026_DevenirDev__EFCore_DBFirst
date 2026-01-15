namespace DemoEFCodeFirst.Models;

public class Actor
{
    public int Id { get; set; }
    public string Lastname { get; set; } = null!;
    public string Firstname { get; set; } = null!;

    //public ICollection<FilmActor> Films { get; set; } = new List<FilmActor>();
}