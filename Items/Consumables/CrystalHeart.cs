using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CrystalHeart : BaseHeart
    {
        public CrystalHeart() : base((int)UniqueIDs.Crystal, 7)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.CrystalShard, TileID.MythrilAnvil);
        }
    }
}
