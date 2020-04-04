namespace WebApp.Models
{
    public class Warehouse
    {
        public virtual int MinCode { get; set; }
        public virtual int MaxCode { get; set; }
        public virtual Company Company { get; set; }
    }
}
