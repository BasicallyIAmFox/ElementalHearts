using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class ChlorophyteHeart : BaseHeart
    {
        public ChlorophyteHeart() : base((int)UniqueIDs.Chlorophyte, 8)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.ChlorophyteOre, TileID.AdamantiteForge);
        }
    }
}
