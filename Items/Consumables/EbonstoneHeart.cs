using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class EbonstoneHeart : BaseHeart
    {
        public EbonstoneHeart() : base((int)UniqueIDs.Ebonstone, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.EbonstoneBlock);
        }
    }
}
