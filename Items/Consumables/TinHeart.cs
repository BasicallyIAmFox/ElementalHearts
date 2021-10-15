using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class TinHeart : BaseHeart
    {
        public TinHeart() : base((int)UniqueIDs.Tin, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.TinOre, TileID.Furnaces);
        }
    }
}
