namespace WebApp.Models.Shared
{
    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
