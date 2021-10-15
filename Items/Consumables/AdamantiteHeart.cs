using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class AdamantiteHeart : BaseHeart
    {
        public AdamantiteHeart() : base((int)UniqueIDs.Adamantite, 7)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.AdamantiteOre, TileID.AdamantiteForge);
        }
    }
}
