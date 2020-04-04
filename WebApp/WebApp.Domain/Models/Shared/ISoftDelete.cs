namespace WebApp.Domain.Models.Shared
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
