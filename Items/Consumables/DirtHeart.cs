using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class DirtHeart : BaseHeart
    {
        public DirtHeart() : base((int)UniqueIDs.Dirt, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.DirtBlock);
        }
    }
}
