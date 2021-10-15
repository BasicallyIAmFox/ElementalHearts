using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class IceHeart : BaseHeart
    {
        public IceHeart() : base((int)UniqueIDs.Ice, 1)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.IceBlock, TileID.IceMachine);
        }
    }
}
