namespace AdidasHack.Core.Entities
{
    public abstract class BaseEntityIdentity : BaseEntityWithoutExplicitId
    {
        public int Id { get; set; }
    }
}
