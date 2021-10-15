using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class RainbowHeart : BaseHeart
    {
        public RainbowHeart() : base((int)UniqueIDs.Rainbow, 5)
        {
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Main.DiscoColor;
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.RainbowBrick, TileID.HeavyWorkBench);
        }
    }
}
