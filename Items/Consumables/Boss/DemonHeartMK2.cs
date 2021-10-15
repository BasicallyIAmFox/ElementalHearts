namespace ElementalHearts.Items.Consumables
{
    public class DemonHeartMK2 : BaseHeart
    {
        public override bool Expert => true;

        public DemonHeartMK2() : base((int)UniqueIDs.DemonMK2, 10)
        {
        }
    }
}
