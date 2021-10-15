namespace ElementalHearts.Items.Consumables
{
    public class WormHeart : BaseHeart
    {
        public override bool Expert => true;

        public WormHeart() : base((int)UniqueIDs.Worm, 5)
        {
        }
    }
}
