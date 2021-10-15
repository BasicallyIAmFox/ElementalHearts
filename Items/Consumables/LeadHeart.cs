using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class LeadHeart : BaseHeart
    {
        public LeadHeart() : base((int)UniqueIDs.Lead, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.LeadOre, TileID.Furnaces);
        }
    }
}
