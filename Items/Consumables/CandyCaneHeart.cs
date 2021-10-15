using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CandyCaneHeart : BaseHeart
    {
        public CandyCaneHeart() : base((int)UniqueIDs.CandyCane, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CandyCaneBlock);
            SimpleAddRecipe(Mod, Type, ItemID.GreenCandyCaneBlock);
        }
    }
}
