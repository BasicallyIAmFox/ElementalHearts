using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class TopazHeart : BaseHeart
    {
        public TopazHeart() : base((int)UniqueIDs.Topaz, 3, ItemRarityID.Green, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Topaz, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
