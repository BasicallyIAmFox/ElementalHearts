using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PalladiumHeart : BaseHeart
    {
        public PalladiumHeart() : base((int)UniqueIDs.Palladium, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PalladiumOre, TileID.Hellforge);
        }
    }
}
