using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class GoldHeart : BaseHeart
    {
        public GoldHeart() : base((int)UniqueIDs.Gold, 3)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.GoldOre, TileID.Furnaces);
        }
    }
}
