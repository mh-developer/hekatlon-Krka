namespace WebApp.Models.Shared
{
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
