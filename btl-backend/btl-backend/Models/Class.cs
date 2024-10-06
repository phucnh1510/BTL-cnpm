namespace btl_backend.Models;

public class Class
{
    public int ClassID { get; set; }

    public ICollection<Problem>? Problem { get; set; }
}