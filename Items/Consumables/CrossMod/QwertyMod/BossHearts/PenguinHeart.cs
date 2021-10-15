namespace ElementalHearts.Items.Consumables
{
    public class PenguinHeart : BaseHeart
    {
        public override bool Expert => true;

        public PenguinHeart() : base((int)UniqueIDs.Penguin, 5)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
