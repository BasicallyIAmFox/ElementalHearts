using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class DiamondHeart : BaseHeart
    {
        public DiamondHeart() : base((int)UniqueIDs.Diamond, 5, ItemRarityID.LightRed, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Diamond, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
