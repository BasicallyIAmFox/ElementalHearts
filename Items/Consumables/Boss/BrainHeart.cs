namespace ElementalHearts.Items.Consumables
{
    public class BrainHeart : BaseHeart
    {
        public override bool Expert => true;

        public BrainHeart() : base((int)UniqueIDs.Brain, 5)
        {
        }
    }
}
