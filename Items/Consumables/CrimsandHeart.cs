using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CrimsandHeart : BaseHeart
    {
        public CrimsandHeart() : base((int)UniqueIDs.Crimsand, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CrimsandBlock, TileID.Furnaces);
        }
    }
}
