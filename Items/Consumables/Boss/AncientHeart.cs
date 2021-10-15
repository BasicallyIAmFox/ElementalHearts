namespace ElementalHearts.Items.Consumables
{
    public class AncientHeart : BaseHeart
    {
        public override bool Expert => true;

        public AncientHeart() : base((int)UniqueIDs.Ancient, 10)
        {
        }
    }
}
