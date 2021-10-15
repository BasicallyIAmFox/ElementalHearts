using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class BorealWoodHeart : BaseHeart
    {
        public BorealWoodHeart() : base((int)UniqueIDs.BorealWood, 1, ItemRarityID.White, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.BorealWood);
        }
    }
}
