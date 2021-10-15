using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PearlsandHeart : BaseHeart
    {
        public PearlsandHeart() : base((int)UniqueIDs.Pearlsand, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PearlsandBlock, TileID.Hellforge);
        }
    }
}
