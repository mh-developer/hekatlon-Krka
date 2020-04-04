namespace WebApp.Models.Shared
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
