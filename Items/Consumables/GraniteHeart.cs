using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class GraniteHeart : BaseHeart
    {
        public GraniteHeart() : base((int)UniqueIDs.Granite, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.GraniteBlock, TileID.Furnaces);
        }
    }
}
