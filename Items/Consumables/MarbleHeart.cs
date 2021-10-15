using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class MarbleHeart : BaseHeart
    {
        public MarbleHeart() : base((int)UniqueIDs.Marble, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Marble, TileID.Furnaces);
        }
    }
}
