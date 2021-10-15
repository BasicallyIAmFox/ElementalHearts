using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class DynastyHeart : BaseHeart
    {
        public DynastyHeart() : base((int)UniqueIDs.Dynasty, 1, ItemRarityID.LightRed, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.DynastyWood);
        }
    }
}
