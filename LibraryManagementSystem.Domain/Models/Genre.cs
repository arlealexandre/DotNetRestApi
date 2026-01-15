public enum Genre
{
    ACTION,
    COMEDY,
    DRAMA,
    HORROR,
    SCIENCE_FICTION
}

public static class GenreExtensions
{
    public static string ToString(this Genre genre)
    {
        return genre switch
        {
            Genre.ACTION => "Action",
            Genre.COMEDY => "Comedy",
            Genre.DRAMA => "Drama",
            Genre.HORROR => "Horror",
            Genre.SCIENCE_FICTION => "Science-Fiction",
            _ => genre.ToString()
        };
    }
}