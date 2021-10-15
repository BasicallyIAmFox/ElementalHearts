using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CrimstoneHeart : BaseHeart
    {
        public CrimstoneHeart() : base((int)UniqueIDs.Crimstone, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CrimstoneBlock);
        }
    }
}
