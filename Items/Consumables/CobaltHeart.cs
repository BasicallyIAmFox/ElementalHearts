using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CobaltHeart : BaseHeart
    {
        public CobaltHeart() : base((int)UniqueIDs.Cobalt, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CobaltOre, TileID.Hellforge);
        }
    }
}
