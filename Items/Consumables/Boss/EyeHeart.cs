namespace ElementalHearts.Items.Consumables
{
    public class EyeHeart : BaseHeart
    {
        public override bool Expert => true;

        public EyeHeart() : base((int)UniqueIDs.Eye, 5)
        {
        }
    }
}
