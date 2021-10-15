using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class RubyHeart : BaseHeart
    {
        public RubyHeart() : base((int)UniqueIDs.Ruby, 4, ItemRarityID.Orange, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Ruby, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
