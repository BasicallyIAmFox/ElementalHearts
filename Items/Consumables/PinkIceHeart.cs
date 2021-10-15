using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PinkIceHeart : BaseHeart
    {
        public PinkIceHeart() : base((int)UniqueIDs.PinkIce, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PinkIceBlock, TileID.IceMachine);
        }
    }
}
