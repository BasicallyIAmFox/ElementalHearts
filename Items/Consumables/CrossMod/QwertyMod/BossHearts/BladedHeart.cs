namespace ElementalHearts.Items.Consumables
{
    public class BladedHeart : BaseHeart
    {
        public override bool Expert => true;

        public BladedHeart() : base((int)UniqueIDs.Bladed, 10)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
