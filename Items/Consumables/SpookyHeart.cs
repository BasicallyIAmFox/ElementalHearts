using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SpookyHeart : BaseHeart
    {
        public SpookyHeart() : base((int)UniqueIDs.Spooky, 7)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpookyWood, 500)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
