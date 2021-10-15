using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class EbonwoodHeart : BaseHeart
    {
        public EbonwoodHeart() : base((int)UniqueIDs.Ebonwood, 1, ItemRarityID.White, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Ebonwood);
        }
    }
}
