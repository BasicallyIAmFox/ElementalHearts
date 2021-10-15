using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofNightHeart : BaseHeart
    {
        public SoulofNightHeart() : base((int)UniqueIDs.SoulofNight, 4, ItemRarityID.Pink)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SoulofNight, TileID.CrystalBall);
        }
    }
}
