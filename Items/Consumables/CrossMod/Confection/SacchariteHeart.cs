using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class SacchariteHeart : BaseHeart
    {
        public SacchariteHeart() : base((int)UniqueIDs.Saccharite, 7)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("Saccharite").Type, TileID.MythrilAnvil);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
