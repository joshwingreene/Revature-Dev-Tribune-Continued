namespace StoreApi.Service.Models
{
  public class Character
  {
    public int EntityId { get; set; }
    public string Name { get; set; }
    public StarTrek StarTrek { get; set; }
    public int StarTrekEntityId { get; set; }
  }
}