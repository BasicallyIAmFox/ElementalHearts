using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class EmeraldHeart : BaseHeart
    {
        public EmeraldHeart() : base((int)UniqueIDs.Emerald, 4, ItemRarityID.Orange, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Emerald, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
