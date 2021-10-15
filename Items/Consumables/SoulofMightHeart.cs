using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofMightHeart : BaseHeart
    {
        public SoulofMightHeart() : base((int)UniqueIDs.SoulofMight, 5, ItemRarityID.LightPurple)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.SoulofMight, TileID.CrystalBall);
        }
    }
}
