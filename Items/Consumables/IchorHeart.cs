using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class IchorHeart : BaseHeart
    {
        public IchorHeart() : base((int)UniqueIDs.Ichor, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Ichor, TileID.CrystalBall);
        }
    }
}
