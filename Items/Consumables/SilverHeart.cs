using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SilverHeart : BaseHeart
    {
        public SilverHeart() : base((int)UniqueIDs.Silver, 3)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SilverOre, TileID.Furnaces);
        }
    }
}
