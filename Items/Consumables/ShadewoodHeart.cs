using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class ShadewoodHeart : BaseHeart
    {
        public ShadewoodHeart() : base((int)UniqueIDs.Shadewood, 1, ItemRarityID.White, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Shadewood);
        }
    }
}
