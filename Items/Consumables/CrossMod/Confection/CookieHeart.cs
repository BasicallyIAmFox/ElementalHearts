using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class CookieHeart : BaseHeart
    {
        public CookieHeart() : base((int)UniqueIDs.Cookie, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("CookieBlock").Type, TileID.Hellforge);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
