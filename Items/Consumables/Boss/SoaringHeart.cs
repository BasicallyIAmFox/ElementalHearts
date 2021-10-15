namespace ElementalHearts.Items.Consumables
{
    public class SoaringHeart : BaseHeart
    {
        public override bool Expert => true;

        public SoaringHeart() : base((int)UniqueIDs.Soaring, 10)
        {
        }
    }
}
