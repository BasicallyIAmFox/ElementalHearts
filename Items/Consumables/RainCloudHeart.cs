using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class RainCloudHeart : BaseHeart
    {
        public RainCloudHeart() : base((int)UniqueIDs.RainCloud, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.RainCloud, TileID.SkyMill);
        }
    }
}
