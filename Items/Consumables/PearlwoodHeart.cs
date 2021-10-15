using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PearlwoodHeart : BaseHeart
    {
        public PearlwoodHeart() : base((int)UniqueIDs.Pearlwood, 5, ItemRarityID.LightRed, 0)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Pearlwood);
        }
    }
}
