using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class CreamstoneHeart : BaseHeart
    {
        public CreamstoneHeart() : base((int)UniqueIDs.Creamstone, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("Creamstone").Type, TileID.Hellforge);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
