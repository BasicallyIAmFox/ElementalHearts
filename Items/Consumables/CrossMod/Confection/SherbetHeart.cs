using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class SherbetHeart : BaseHeart
    {
        public SherbetHeart() : base((int)UniqueIDs.Sherbet, 5)
        {
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Main.DiscoColor;
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("SherbetBricks").Type, TileID.HeavyWorkBench);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
