using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class TungstenHeart : BaseHeart
    {
        public TungstenHeart() : base((int)UniqueIDs.Tungsten, 3)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.TungstenOre, TileID.Furnaces);
        }
    }
}
