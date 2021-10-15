namespace ElementalHearts.Items.Consumables
{
    public class CelestialHeart : BaseHeart
    {
        public override bool Expert => true;

        public CelestialHeart() : base((int)UniqueIDs.Celestial, 10)
        {
        }
    }
}
