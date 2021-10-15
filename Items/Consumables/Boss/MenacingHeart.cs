namespace ElementalHearts.Items.Consumables
{
    public class MenacingHeart : BaseHeart
    {
        public override bool Expert => true;

        public MenacingHeart() : base((int)UniqueIDs.Menacing, 5)
        {
        }
    }
}
