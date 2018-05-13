namespace AdidasHack.Core.Entities
{
    public interface IBaseEntityIdentity : IBaseEntityWithoutExplicitId
    {
        int Id { get; set; }
    }
}
