namespace ElementalHearts.Items.Consumables
{
    public class HydraHeart : BaseHeart
    {
        public override bool Expert => true;

        public HydraHeart() : base((int)UniqueIDs.Hydra, 10)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
