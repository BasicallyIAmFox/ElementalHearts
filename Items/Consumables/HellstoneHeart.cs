using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class HellstoneHeart : BaseHeart
    {
        public HellstoneHeart() : base((int)UniqueIDs.Hellstone, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Hellstone, TileID.Hellforge);
        }
    }
}
