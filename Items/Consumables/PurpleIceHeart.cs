using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class PurpleIceHeart : BaseHeart
    {
        public PurpleIceHeart() : base((int)UniqueIDs.PurpleIce, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.PurpleIceBlock, TileID.IceMachine);
        }
    }
}
