namespace ElementalHearts.Items.Consumables
{
    public class TruffleHeart : BaseHeart
    {
        public override bool Expert => true;

        public TruffleHeart() : base((int)UniqueIDs.Truffle, 10)
        {
        }
    }
}
