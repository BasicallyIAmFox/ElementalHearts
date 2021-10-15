using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class FleshHeart : BaseHeart
    {
        public FleshHeart() : base((int)UniqueIDs.Flesh, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.FleshBlock, TileID.FleshCloningVat);
        }
    }
}
