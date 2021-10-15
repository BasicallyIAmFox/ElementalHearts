namespace ElementalHearts.Items.Consumables
{
    public class RoyalSlimeHeart : BaseHeart
    {
        public override bool Expert => true;

        public RoyalSlimeHeart() : base((int)UniqueIDs.RoyalSlime, 5)
        {
        }
    }
}
