namespace ElementalHearts.Items.Consumables
{
    public class LihzhardianHeart : BaseHeart
    {
        public override bool Expert => true;

        public LihzhardianHeart() : base((int)UniqueIDs.Lihzhardian, 10)
        {
        }
    }
}
