namespace ElementalHearts.Items.Consumables
{
    public class LarvaoftheHives : BaseHeart
    {
        public override bool Expert => true;

        public LarvaoftheHives() : base((int)UniqueIDs.LarvaoftheHives, 5)
        {
        }
    }
}
