using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SandHeart : BaseHeart
    {
        public SandHeart() : base((int)UniqueIDs.Sand, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SandBlock);
        }
    }
}
