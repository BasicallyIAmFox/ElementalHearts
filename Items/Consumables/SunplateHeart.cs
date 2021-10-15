using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SunplateHeart : BaseHeart
    {
        public SunplateHeart() : base((int)UniqueIDs.Sunplate, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SunplateBlock, TileID.SkyMill);
        }
    }
}
