using Terraria;
using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class CogHeart : BaseHeart
    {
        public CogHeart() : base((int)UniqueIDs.Cog, 5, value: Item.buyPrice(gold: 2))
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Cog, TileID.SteampunkBoiler);
        }
    }
}
