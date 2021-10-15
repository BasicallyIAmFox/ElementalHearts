using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class WoodHeart : BaseHeart
    {
        public WoodHeart() : base((int)UniqueIDs.Wood, 1, ItemRarityID.White, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Wood);
        }
    }
}
