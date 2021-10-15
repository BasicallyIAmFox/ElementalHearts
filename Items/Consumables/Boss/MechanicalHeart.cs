using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class MechanicalHeart : BaseHeart
    {
        public override bool Expert => true;

        public MechanicalHeart() : base((int)UniqueIDs.Mechanical, 10)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MechanicalCrystalPiece1>())
                .AddIngredient(ModContent.ItemType<MechanicalCrystalPiece2>())
                .AddIngredient(ModContent.ItemType<MechanicalCrystalPiece3>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
