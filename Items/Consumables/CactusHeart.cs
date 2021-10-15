using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CactusHeart : BaseHeart
    {
        public CactusHeart() : base((int)UniqueIDs.Cactus, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Cactus);
        }
    }
}
