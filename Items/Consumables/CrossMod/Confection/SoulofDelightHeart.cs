using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofDelightHeart : BaseHeart
    {
        public SoulofDelightHeart() : base((int)UniqueIDs.SoulofDelight, 4, ItemRarityID.Pink)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("SoulofDelight").Type, TileID.CrystalBall);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
