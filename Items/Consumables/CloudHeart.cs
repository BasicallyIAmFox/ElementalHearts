using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CloudHeart : BaseHeart
    {
        public CloudHeart() : base((int)UniqueIDs.Cloud, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Cloud, TileID.SkyMill);
        }
    }
}
