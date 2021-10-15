using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofFlightHeart : BaseHeart
    {
        public SoulofFlightHeart() : base((int)UniqueIDs.SoulofFlight, 4, ItemRarityID.Pink)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SoulofFlight, TileID.CrystalBall);
        }
    }
}
