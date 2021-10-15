using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SapphireHeart : BaseHeart
    {
        public SapphireHeart() : base((int)UniqueIDs.Sapphire, 3, ItemRarityID.Green, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sapphire, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
