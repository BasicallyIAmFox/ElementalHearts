using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PearlstoneHeart : BaseHeart
    {
        public PearlstoneHeart() : base((int)UniqueIDs.Pearlstone, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PearlstoneBlock, TileID.Hellforge);
        }
    }
}
