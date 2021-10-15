using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofFrightHeart : BaseHeart
    {
        public SoulofFrightHeart() : base((int)UniqueIDs.SoulofFright, 5, ItemRarityID.LightPurple)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SoulofFright, TileID.CrystalBall);
        }
    }
}
