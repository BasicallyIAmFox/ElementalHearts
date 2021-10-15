using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CrimtaneHeart : BaseHeart
    {
        public CrimtaneHeart() : base((int)UniqueIDs.Crimtane, 4)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CrimtaneOre, TileID.Furnaces);
        }
    }
}
