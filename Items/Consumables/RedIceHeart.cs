using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class RedIceHeart : BaseHeart
    {
        public RedIceHeart() : base((int)UniqueIDs.RedIce, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.RedIceBlock, TileID.IceMachine);
        }
    }
}
