using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class LesionHeart : BaseHeart
    {
        public LesionHeart() : base((int)UniqueIDs.Lesion, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.LesionBlock, TileID.LesionStation);
        }
    }
}
