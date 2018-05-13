namespace AdidasHack.Core.Entities
{
    public class GearAccessory : BaseEntity
    {
        public int GearId { get; set; }

        public Gear Gear { get; set; }
    }
}
