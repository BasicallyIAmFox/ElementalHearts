using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class HayHeart : BaseHeart
    {
        public HayHeart() : base((int)UniqueIDs.Granite, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Hay, TileID.Sawmill);
        }
    }
}
