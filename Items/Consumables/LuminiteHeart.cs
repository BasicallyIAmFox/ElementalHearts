using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class LuminiteHeart : BaseHeart
    {
        public LuminiteHeart() : base((int)UniqueIDs.Luminite, 9, ItemRarityID.Red)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarOre, 60)
                .AddIngredient(ItemID.FragmentVortex, 10)
                .AddIngredient(ItemID.FragmentNebula, 10)
                .AddIngredient(ItemID.FragmentSolar, 10)
                .AddIngredient(ItemID.FragmentStardust, 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
