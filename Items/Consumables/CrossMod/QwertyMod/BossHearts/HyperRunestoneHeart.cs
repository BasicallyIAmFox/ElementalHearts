namespace ElementalHearts.Items.Consumables
{
    public class HyperRunestoneHeart : BaseHeart
    {
        public override bool Expert => true;

        public HyperRunestoneHeart() : base((int)UniqueIDs.HyperRunestone, 10)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
