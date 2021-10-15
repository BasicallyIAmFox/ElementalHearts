using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class HoneyHeart : BaseHeart
    {
        public HoneyHeart() : base((int)UniqueIDs.Honey, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.HoneyBlock, TileID.HoneyDispenser);
        }
    }
}
