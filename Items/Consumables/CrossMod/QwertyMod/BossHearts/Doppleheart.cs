namespace ElementalHearts.Items.Consumables
{
    public class Doppleheart : BaseHeart
    {
        public override bool Expert => true;

        public Doppleheart() : base((int)UniqueIDs.Doppleheart, 5)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
