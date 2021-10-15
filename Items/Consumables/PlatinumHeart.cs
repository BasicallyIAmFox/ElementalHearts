using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PlatinumHeart : BaseHeart
    {
        public PlatinumHeart() : base((int)UniqueIDs.Platinum, 3)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PlatinumOre, TileID.Furnaces);
        }
    }
}
