using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SnowCloudHeart : BaseHeart
    {
        public SnowCloudHeart() : base((int)UniqueIDs.SnowCloud, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SnowCloudBlock, TileID.SkyMill);
        }
    }
}
