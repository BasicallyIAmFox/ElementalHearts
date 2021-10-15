using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class ZenithHeart : BaseHeart
    {
        public ZenithHeart() : base((int)UniqueIDs.Zenith, 10, ItemRarityID.Red)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CopperHeart>())
                .AddIngredient(ModContent.ItemType<CandyCaneHeart>())
                .AddIngredient(ModContent.ItemType<EnchantedHeart>())
                .AddIngredient(ModContent.ItemType<HoneyHeart>())
                .AddIngredient(ModContent.ItemType<SunplateHeart>())
                .AddIngredient(ModContent.ItemType<ChlorophyteHeart>())
                .AddIngredient(ModContent.ItemType<SpookyHeart>())
                // Martian Heart
                .AddIngredient(ModContent.ItemType<LuminiteHeart>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
