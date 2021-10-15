using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class StoneHeart : BaseHeart
    {
        public StoneHeart() : base((int)UniqueIDs.Stone, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.StoneBlock, TileID.Furnaces);
        }
    }
}
