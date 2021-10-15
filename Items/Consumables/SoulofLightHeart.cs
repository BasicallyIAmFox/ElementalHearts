using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofLightHeart : BaseHeart
    {
        public SoulofLightHeart() : base((int)UniqueIDs.SoulofLight, 4, ItemRarityID.Pink)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SoulofLight, TileID.CrystalBall);
        }
    }
}
