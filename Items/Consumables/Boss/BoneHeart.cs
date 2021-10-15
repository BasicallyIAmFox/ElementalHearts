namespace ElementalHearts.Items.Consumables
{
    public class BoneHeart : BaseHeart
    {
        public override bool Expert => true;

        public BoneHeart() : base((int)UniqueIDs.Bone, 5)
        {
        }
    }
}
