using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class AmethystHeart : BaseHeart
    {
        public AmethystHeart() : base((int)UniqueIDs.Amethyst, 2, ItemRarityID.Blue, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
