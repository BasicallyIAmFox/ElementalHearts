using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PumpkinHeart : BaseHeart
    {
        public PumpkinHeart() : base((int)UniqueIDs.Pumpkin, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Pumpkin, TileID.Furnaces);
        }
    }
}
