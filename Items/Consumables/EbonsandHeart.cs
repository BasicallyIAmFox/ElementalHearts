using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class EbonsandHeart : BaseHeart
    {
        public EbonsandHeart() : base((int)UniqueIDs.Ebonsand, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.EbonsandBlock, TileID.Furnaces);
        }
    }
}
