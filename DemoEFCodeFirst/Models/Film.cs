namespace DemoEFCodeFirst.Models;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int ReleasedYear { get; set; }
    public int CreatorId { get; set; }

    public Creator Creator { get; set; } = null!;
    //public ICollection<FilmActor> Actors { get; set; } = new List<FilmActor>();
    
}
