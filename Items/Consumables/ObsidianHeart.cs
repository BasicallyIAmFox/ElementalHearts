using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class ObsidianHeart : BaseHeart
    {
        public ObsidianHeart() : base((int)UniqueIDs.Obsidian, 3)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Obsidian, TileID.Hellforge);
        }
    }
}
