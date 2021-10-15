using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class IronHeart : BaseHeart
    {
        public IronHeart() : base((int)UniqueIDs.Iron, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.IronOre, TileID.Furnaces);
        }
    }
}
