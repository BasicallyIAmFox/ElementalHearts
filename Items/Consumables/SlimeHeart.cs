using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class SlimeHeart : BaseHeart
    {
        public SlimeHeart() : base((int)UniqueIDs.Slime, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Gel, TileID.Solidifier);
        }
    }
}
