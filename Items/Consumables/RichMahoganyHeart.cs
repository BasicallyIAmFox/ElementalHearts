using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class RichMahoganyHeart : BaseHeart
    {
        public RichMahoganyHeart() : base((int)UniqueIDs.RichMahogany, 1, ItemRarityID.White, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.RichMahogany);
        }
    }
}
