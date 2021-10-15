namespace ElementalHearts.Items.Consumables
{
    public class DevouringHeart : BaseHeart
    {
        public override bool Expert => true;

        public DevouringHeart() : base((int)UniqueIDs.Devouring, 10)
        {
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
