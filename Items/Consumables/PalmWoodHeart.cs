using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PalmWoodHeart : BaseHeart
    {
        public PalmWoodHeart() : base((int)UniqueIDs.PalmWood, 1, ItemRarityID.White, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PalmWood);
        }
    }
}
