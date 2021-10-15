using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class GlassHeart : BaseHeart
    {
        public GlassHeart() : base((int)UniqueIDs.Glass, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Glass, TileID.GlassKiln);
        }
    }
}
