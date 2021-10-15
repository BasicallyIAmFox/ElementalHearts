using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CursedFlameHeart : BaseHeart
    {
        public CursedFlameHeart() : base((int)UniqueIDs.CursedFlame, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CursedFlame, TileID.CrystalBall);
        }
    }
}
