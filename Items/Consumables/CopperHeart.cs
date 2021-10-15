using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CopperHeart : BaseHeart
    {
        public CopperHeart() : base((int)UniqueIDs.Copper, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CopperOre, TileID.Furnaces);
        }
    }
}
