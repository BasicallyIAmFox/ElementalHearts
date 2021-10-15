using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class MushroomHeart : BaseHeart
    {
        public MushroomHeart() : base((int)UniqueIDs.Mushroom, 2)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Mushroom, 50)
                .AddIngredient(ItemID.GlowingMushroom, 50)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
