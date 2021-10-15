using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofSightHeart : BaseHeart
    {
        public SoulofSightHeart() : base((int)UniqueIDs.SoulofSight, 5, ItemRarityID.LightPurple)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SoulofSight, TileID.CrystalBall);
        }
    }
}
