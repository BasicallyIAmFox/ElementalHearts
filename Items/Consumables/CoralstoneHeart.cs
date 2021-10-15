using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CoralstoneHeart : BaseHeart
    {
        public CoralstoneHeart() : base((int)UniqueIDs.Coralstone, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CoralstoneBlock, TileID.Sinks);
        }
    }
}
