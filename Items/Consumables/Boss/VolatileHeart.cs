namespace ElementalHearts.Items.Consumables
{
    public class VolatileHeart : BaseHeart
    {
        public override bool Expert => true;

        public VolatileHeart() : base((int)UniqueIDs.Volatile, 10)
        {
        }
    }
}
