using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class AmberHeart : BaseHeart
    {
        public AmberHeart() : base((int)UniqueIDs.Amber, 5, ItemRarityID.LightRed, 0)
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amber, 25)
                .AddIngredient(ItemID.StoneBlock, 75)
                .AddTile(TileID.Extractinator)
                .Register();
        }
    }
}
