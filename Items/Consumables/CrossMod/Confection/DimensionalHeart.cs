using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class DimensionalHeart : BaseHeart
    {
        public DimensionalHeart() : base((int)UniqueIDs.Dimensional, 6, ItemRarityID.Lime)
        {
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
