namespace StoreApi.Service.Models.Abstracts
{
    public abstract class AUser : AEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
