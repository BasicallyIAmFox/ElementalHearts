using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class DemoniteHeart : BaseHeart
    {
        public DemoniteHeart() : base((int)UniqueIDs.Demonite, 4)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.DemoniteOre, TileID.Furnaces);
        }
    }
}
