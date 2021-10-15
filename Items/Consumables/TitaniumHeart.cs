using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class TitaniumHeart : BaseHeart
    {
        public TitaniumHeart() : base((int)UniqueIDs.Titanium, 7)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.TitaniumOre, TileID.AdamantiteForge);
        }
    }
}
