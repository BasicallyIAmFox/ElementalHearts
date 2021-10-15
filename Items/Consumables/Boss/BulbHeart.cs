namespace ElementalHearts.Items.Consumables
{
    public class BulbHeart : BaseHeart
    {
        public override bool Expert => true;

        public BulbHeart() : base((int)UniqueIDs.Bulb, 10)
        {
        }
    }
}
