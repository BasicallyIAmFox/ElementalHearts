namespace ElementalHearts.Items.Consumables
{
    public class Ancient2Heart : BaseHeart
    {
        public override bool Expert => true;

        public Ancient2Heart() : base((int)UniqueIDs.Ancient2, 5)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
