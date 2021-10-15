namespace ElementalHearts.Items.Consumables
{
    public class DivineHeart : BaseHeart
    {
        public override bool Expert => true;

        public DivineHeart() : base((int)UniqueIDs.Divine, 5)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
